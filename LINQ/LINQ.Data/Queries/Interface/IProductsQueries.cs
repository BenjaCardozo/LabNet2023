using LINQ.Entities.DTO;
using System.Collections.Generic;
using System.ComponentModel;

namespace LINQ.Data.Queries.Interface
{
    public interface IProductsQueries
    {
        List<Products> WhitoutStock();
        List<Products> WhithStockAndPriceperUnitHigherthree();
        List<Products> GetAll();
        List<Categories> JoinCategoryProduct();
    }
}
