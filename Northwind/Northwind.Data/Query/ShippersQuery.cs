using Northwind.Data.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Query
{
    public class ShippersQuery : IQueryGeneric<Shippers, int>
    {
        public bool ExistID(int id)
        {
            try
            {
                using (var _context = new NorthwindContext())
                {
                    return _context.Shippers.Any(s => s.ShipperID == id);
                }
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
                using (var _context = new NorthwindContext())
                {
                    return _context.Shippers.ToList();
                }
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
                using (var _context = new NorthwindContext())
                {
                    return _context.Shippers.First(s => s.ShipperID == id);
                }
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
                using (var _context = new NorthwindContext())
                {
                    return _context.Shippers.Max(c => c.ShipperID);
                }
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
                using (var _context = new NorthwindContext())
                {
                    return _context.Shippers
                        .Where(s => s.CompanyName.Contains(str))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
