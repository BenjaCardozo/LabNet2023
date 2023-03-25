using Northwind.Data;
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
                return _logic.GetAll().Select(categorie => MapViewModel(categorie)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CategoriesViewModel GetById(int id)
        {
            try
            {
                return MapViewModel(_logic.GetByID(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(CategoriesViewModel categorieViewModel)
        {
            try
            {
                _logic.Add(MapDomainModel(categorieViewModel));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Edit(CategoriesViewModel categorieViewModel)
        {
            try
            {
                _logic.Update(MapDomainModel(categorieViewModel));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _logic.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CategoriesViewModel MapViewModel(Categories categories)
        {
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel
            {
                CategoryID = categories.CategoryID,
                CategoryName = categories.CategoryName,
                CategoryDescription = categories.Description
            };
            return categoriesViewModel;
        }
        public Categories MapDomainModel(CategoriesViewModel categoriesViewModel)
        {
            Categories categories = new Categories();

            if (categoriesViewModel.CategoryID == null)
            {
                categories.CategoryID = _logic.GetAll().Select(s => s.CategoryID).Last();
            }
            else
            {
                categories.CategoryID = (int)categoriesViewModel.CategoryID;
            }
            categories.CategoryName = categoriesViewModel.CategoryName;
            categories.Description = categoriesViewModel.CategoryDescription;
            return categories;
        }
    }
}