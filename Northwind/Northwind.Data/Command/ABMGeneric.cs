using Northwind.Data.Command.Interface;
using System;
using System.Data.Entity;

namespace Northwind.Data.Command
{
    public class ABMGeneric<T> : IABMGeneric<T> where T : class, new()
    {
        private readonly NorthwindContext _context;
        public ABMGeneric(NorthwindContext context) 
        {
            _context = context;
        }
        public ABMGeneric() 
        {
            _context = new NorthwindContext();
        }
        public void Add(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
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
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
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
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
