using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Northwind.Data.Query.Interface
{
    public class CategoriesQuery : IQueryGeneric<Categories, int>
    {
        private readonly NorthwindContext _context;
        public CategoriesQuery(NorthwindContext context)
        {
            _context = context;
        }
        public CategoriesQuery() 
        {
            _context = new NorthwindContext();
        }
        public List<Categories> GetAll()
        {
            try
            {
                List<Categories> categories = _context.Categories.ToList();
                return categories;
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
                Categories category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
                return category;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual bool ExistID(int id)
        {
            try
            {
                bool existID = _context.Categories.Any(c => c.CategoryID == id);
                return existID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual int LastID()
        {
            try
            {
                int lastID = _context.Categories.Max(c=> c.CategoryID);
                return lastID;
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
                List<Categories> categories = _context.Categories
                    .Where(c => c.CategoryName.Contains(str))
                    .ToList();
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
