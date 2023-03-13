using NorthWindPractica.Data.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Data.Query
{
    public class CategoriesQuery : IQueryGeneric<Categories, int>
    {
        private readonly NorthwindContext _context;
        public CategoriesQuery()=> _context = new NorthwindContext();
        public List<Categories> GetAll()
        {
            try
            {
                using (_context)
                {
                    return _context.Categories.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Categories GetByID(int id)
        {
            try
            {
                using (_context)
                {
                    return _context.Categories.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ExistID(int id)
        {
            try
            {
                using (_context)
                {
                    return _context.Categories.Any(c => c.CategoryID == id);
                }                
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
