using Northwind.Data.Command.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Command
{
    public class ABMGeneric<T> : IABMGeneric<T> where T : class, new()
    {
        public void Add(T entity)
        {
            try
            {
                using (var _context = new NorthwindContext())
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
                using (var _context = new NorthwindContext())
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
                using (var _context = new NorthwindContext())
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
