using LINQ.Data;
using LINQ.Data.Queries;
using LINQ.Data.Queries.Interface;
using LINQ.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Logic.Application
{
    public class ProductsApplication
    {
        private readonly IProductsQueries productsQueries;

        public ProductsApplication() 
        {
            productsQueries = new ProductsQueries();
        }

        public List<Products> ProductsWhithoutStock()
        {
            try
            {
                return productsQueries.WhitoutStock();
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
                return productsQueries.WhithStockAndPriceperUnitHigherthree();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Products BuscarELID()
        {
            List<Products> products = productsQueries.GetAll();
            Products product = products.FirstOrDefault(p => p.ProductID == 789);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Producto no encontrado");
            }
        }
        public List<string> OrderByName()
        {
            try
            {
                List<Products> products = productsQueries.GetAll();
                return products.OrderBy(p => p.ProductName).Select(p=> p.ProductName).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Products> OrderByStock() 
        {
            try
            {
                List<Products> products = productsQueries.GetAll();
                var query = from product in products
                            orderby product.UnitsInStock descending
                            select product;
                return query.ToList();
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
                return productsQueries.JoinCategoryProduct();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Products FirsElement()
        {
            try
            {
                List<Products> products = productsQueries.GetAll();
                return products.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
