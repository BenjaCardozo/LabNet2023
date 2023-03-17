using LINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Data.Query.Interface
{
    public interface ICustomersQueries
    {
        Customers GetCustomer();
        List<Customers> WhereRegionIsWA();
        List<string> GetName();
        List<CustomerOrderDTO> JoinCustomersOrders();
        List<CustomerOrderCountDTO> JoinCustomerOrdersCount();
    }
}
