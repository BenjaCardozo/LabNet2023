using LINQ.Data;
using LINQ.Data.Query;
using LINQ.Data.Query.Interface;
using LINQ.Entities.DTO;
using System;
using System.Collections.Generic;

namespace LINQ.Logic.Application
{
    public class CustomerApplication
    {
        private readonly ICustomersQueries _queries;

        public CustomerApplication() 
        {
            _queries = new CustomersQueries();
        }
        public Customers GetCustomerByID()
        {
            try
            {
               return _queries.GetCustomer();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Customers> RegionIsWA()
        {
            try
            {
                return _queries.WhereRegionIsWA();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<string> GetCustomersName()
        {
            try
            {
                return _queries.GetName();
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
                return _queries.JoinCustomersOrders();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CustomerOrderCountDTO> JoinCustomersOrdersCount()
        {
            try
            {
                return _queries.JoinCustomerOrdersCount();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
