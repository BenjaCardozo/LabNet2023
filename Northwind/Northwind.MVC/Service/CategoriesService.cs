using Northwind.Logic.Application;
using Northwind.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.MVC.Service
{
    public class CategoriesService
    {
        private readonly CategoriesLogic _logic;

        public CategoriesService()
        {
            _logic = new CategoriesLogic();
        }

        public List<CategoriesViewModel> GetAll()
        {
            try
            {
                return _logic.GetAll().Select(c => new CategoriesViewModel
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.Description
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}