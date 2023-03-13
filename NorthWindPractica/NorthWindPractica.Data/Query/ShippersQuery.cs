using NorthWindPractica.Data.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Data.Query
{
    public class ShippersQuery : IQueryGeneric<Shippers, int>
    {
        private readonly NorthwindContext _context;
        public ShippersQuery() => _context = new NorthwindContext();

        public bool ExistID(int id)
        {
            try
            {
                using (_context)
                {
                    return _context.Shippers.Any(s=> s.ShipperID == id);
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
                using (_context)
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
                using (_context)
                {
                    return _context.Shippers.First(s=> s.ShipperID == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
