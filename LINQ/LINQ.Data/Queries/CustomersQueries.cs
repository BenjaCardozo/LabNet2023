using LINQ.Data.Queries;
using LINQ.Data.Query.Interface;
using LINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Data.Query
{
    public class CustomersQueries : BaseQueries, ICustomersQueries
    {
        public Customers GetCustomer()
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    return (from customer in _context.Customers
                            select customer).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Customers> WhereRegionIsWA()
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    var customers =  (from customer in _context.Customers
                            where customer.Region == "WA"
                            select customer);
                    return customers.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<string> GetName()
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    var customers = (from customer in _context.Customers
                                     select customer.CompanyName).ToList();
                    return customers;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CustomerOrderDTO> JoinCustomersOrders()
        {
            try
            {
                using(_context = new NorthwindContext())
                {
                    var query = _context.Customers
                                .Join(_context.Orders,
                                    customer => customer.CustomerID,
                                    order => order.CustomerID,
                                    (customer, order) => new { Customer = customer, Order = order })
                                .Where(c => c.Customer.Region == "WA" && c.Order.OrderDate > new DateTime(1997, 1, 1))
                                .Select(c => new CustomerOrderDTO
                                {
                                    CustomerName = c.Customer.ContactName,
                                    OrderDate = (DateTime)c.Order.OrderDate,
                                    Region = c.Customer.Region
                                });

                    return query.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CustomerOrderCountDTO> JoinCustomerOrdersCount()
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    var query = from c in _context.Customers
                                join o in _context.Orders on c.CustomerID equals o.CustomerID into ordersGroup
                                select new CustomerOrderCountDTO
                                {
                                    CustomerName = c.ContactName,
                                    ContactTitle = c.ContactTitle,
                                    OrderCount = ordersGroup.Count()
                                };

                    return query.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
