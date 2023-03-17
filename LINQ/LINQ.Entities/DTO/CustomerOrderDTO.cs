using System;

namespace LINQ.Entities.DTO
{
    public class CustomerOrderDTO
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Region { get; set; }
    }
}
