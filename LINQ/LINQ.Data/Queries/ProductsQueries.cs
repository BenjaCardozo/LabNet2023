using LINQ.Data.Queries.Interface;
using LINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Data.Queries
{
	public class ProductsQueries : BaseQueries, IProductsQueries
    {
        public List<Products> WhitoutStock()
        {
			try
			{
				using(_context = new NorthwindContext())
				{
					return _context.Products.Where(p => p.UnitsInStock == 0).ToList();
				}
			}
			catch (Exception)
			{
				throw;
			}
        }
        public List<Products> WhithStockAndPriceperUnitHigherthree()
        {
			try
			{
				using(_context = new NorthwindContext())
				{
					return _context.Products.Where(p=> p.UnitsInStock > 0 && p.UnitPrice > 3)
						.OrderBy(p=> p.UnitPrice)
						.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
        }

        public List<Products> GetAll()
        {
            try
            {
                using (_context = new NorthwindContext())
                {
                    return _context.Products.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
		public List<Categories> JoinCategoryProduct()
		{
			try
			{
				using (_context = new NorthwindContext())
				{
					var query = (from c in _context.Categories
								join p in _context.Products on c.CategoryID equals p.CategoryID
								select c);
                    return query.ToList();
                }
			}
			catch (Exception)
			{
				throw;
			}
		}
    }
}
