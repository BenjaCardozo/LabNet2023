using Northwind.Data;
using Northwind.Data.Command;
using Northwind.Data.Command.Interface;
using Northwind.Data.Query.Interface;
using Northwind.Util.Exceptions;
using System;
using System.Collections.Generic;

namespace Northwind.Logic.Application
{
    public class CategoriesLogic
    {
        private IABMGeneric<Categories> _command;
        private IQueryGeneric<Categories, int> _query;
        
        public CategoriesLogic() 
        {
            _command = new ABMGeneric<Categories>();
            _query = new CategoriesQuery();
        }
        public CategoriesLogic (ABMGeneric<Categories> command, CategoriesQuery query)
        {
            _command = command;
            _query = query;
        }
        public void Add(Categories newCategory)
        {
            try
            {
                int id = _query.LastID() + 1;

                while (_query.ExistID(id))
                {
                    id = _query.LastID() + 1;
                }
                newCategory.CategoryID = id;

                _command.Add(newCategory);
            }
            catch (Exception)
            {
                throw new MyException("Error al agregar la categoria.");
            }
        }
        public void Update(Categories updateCategory)
        {
            try
            {
                Categories existingCategory = _query.GetByID(updateCategory.CategoryID);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = updateCategory.CategoryName;
                    existingCategory.Description = updateCategory.Description;
                    _command.Update(existingCategory);
                } else
                {
                    throw new MyException("La categoria que desea modificar no existe.");
                }
            }
            catch (MyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new MyException("Error al modificar la categoria.");
            }
        }
        public void Delete(int categoryId)
        {
            try
            {
                Categories categoryToDelete = _query.GetByID(categoryId);
                if (categoryToDelete != null)
                {
                    _command.Delete(categoryToDelete);
                }
                else
                {
                    throw new MyException("La categoria que desea eliminar no existe.");
                }
            }
            catch (MyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new MyException("Error al eliminar la categoria.");
            }
        }
        public List<Categories> GetAll()
        {
            try
            {
                return _query.GetAll();
            }
            catch (Exception)
            {
                throw new MyException("Error al obtener todas las categorias.");
            }
        }
        public Categories GetByID(int categoryId)
        {
            try
            {
                return _query.GetByID(categoryId);
            }
            catch (Exception)
            {
                throw new MyException("Error al obtener la categoria.");
            }
        }
        public List<Categories> GetByString(string str)
        {
            try
            {
                return _query.GetByString(str);
            }
            catch (Exception)
            {
                throw new MyException("Error al obtener la categoria por nombre.");
            }
        }
    }
}
