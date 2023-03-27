using Northwind.Data.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Data.Query
{
    public class ShippersQuery : IQueryGeneric<Shippers, int>
    {
        private readonly NorthwindContext _context;
        public ShippersQuery (NorthwindContext context)
        {
            _context = context;
        }
        public ShippersQuery() 
        {
            _context= new NorthwindContext();
        }
        public bool ExistID(int id)
        {
            try
            {
                bool existID = _context.Shippers.Any(s => s.ShipperID == id);
                return existID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Shippers> GetAll()
        {
            try
            {
                List<Shippers> shippers = _context.Shippers.ToList();
                return shippers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Shippers GetByID(int id)
        {
            try
            {
                Shippers shipper = _context.Shippers.FirstOrDefault(s => s.ShipperID == id);
                return shipper;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int LastID()
        {
            try
           
            {
                int id = _context.Shippers.Max(c => c.ShipperID);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Shippers> GetByString(string str)
        {
            try
            {
                List<Shippers> shippers = _context.Shippers
                    .Where(s => s.CompanyName.Contains(str))
                    .ToList();
                return shippers;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
