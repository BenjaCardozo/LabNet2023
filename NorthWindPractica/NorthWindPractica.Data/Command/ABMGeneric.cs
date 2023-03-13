using NorthWindPractica.Data.Command.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Data.Command
{
    public class ABMGeneric<T> : IABMGeneric<T> where T : class, new()
    {
        private readonly NorthwindContext _context;
        public ABMGeneric() => _context = new NorthwindContext();
        public void Add(T entity)
        {
            try
            {
                using (_context)
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
                using (_context)
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
                using(_context)
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
