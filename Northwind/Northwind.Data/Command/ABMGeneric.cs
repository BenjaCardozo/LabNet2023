using Northwind.Data.Command.Interface;
using System;
using System.Data.Entity;

namespace Northwind.Data.Command
{
    public class ABMGeneric<T> : IABMGeneric<T> where T : class, new()
    {
        private NorthwindContext _context;
        public ABMGeneric(NorthwindContext context) 
        {
            _context = context;
        }
        public ABMGeneric() { }
        public void Add(T entity)
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(T entity)
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    _context.Entry(entity).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(T entity)
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
