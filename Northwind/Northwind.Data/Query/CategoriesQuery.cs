using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Query.Interface
{
    public class CategoriesQuery : IQueryGeneric<Categories, int>
    {
        public List<Categories> GetAll()
        {
            try
            {
                using (var _context = new NorthwindContext())
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
                using (var _context = new NorthwindContext())
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
                using (var _context = new NorthwindContext())
                {
                    return _context.Categories.Any(c => c.CategoryID == id);
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
                    return _context.Categories.Max(c=> c.CategoryID);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Categories> GetByString(string str)
        {
            try
            {
                using (var _context = new NorthwindContext())
                {
                    return _context.Categories
                        .Where(c => c.CategoryName.Contains(str))
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
