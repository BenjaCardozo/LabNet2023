using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Entities.DTO
{
    public class CustomerOrderCountDTO
    {
        public string CustomerName { get; set; }
        public string ContactTitle { get; set; }
        public int OrderCount { get; set; }
    }
}
