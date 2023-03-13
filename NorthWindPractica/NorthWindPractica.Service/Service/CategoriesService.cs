using NorthWindPractica.Data;
using NorthWindPractica.Logic.Logic;
using NorthWindPractica.Service.Interface;
using NorthWindPractica.Service.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Service.Service
{
    public class CategoriesService : IABMService<Categories, int>
    {
        private CategoriesLogic _logic;
        public CategoriesService() => _logic = new CategoriesLogic();
        public IEnumerable<Categories> GetAll()
        {
            try
            {
                return _logic.GetAll();
            }
            catch (Exception ex)
            {

                throw new ServiceException("Error al listar categorias.", ex);
            }
        }
        public Categories GetById(int id)
        {
            try
            {
                return _logic.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error al obtener categoria.", ex);
            }
        }
        public void Add(Categories newCategory)
        {
            int id = _logic.IdGenerator();
            bool idExist = _logic.ExistID(id);
            if (!idExist)
            {
                try
                {
                    newCategory.CategoryID = id;
                    _logic.Add(newCategory);
                }
                catch (Exception ex)
                {
                    throw new ServiceException("Error al agregar una categoria", ex);
                }
            }
        }
        public void Delete(int id)
        {
            bool idExist = _logic.ExistID(id);
            if (idExist)
            {
                try
                {
                    Categories categoryToDelete = GetById(id);
                    _logic.Delete(categoryToDelete);
                }
                catch (Exception ex)
                {
                    throw new ServiceException("Error al eliminar categoria.", ex);
                }                
            }
        }
        
        public void Update(Categories updateCategory)
        {
            bool existID = _logic.ExistID(updateCategory.CategoryID);

            if (existID)
            {
                try
                {
                    _logic.Update(updateCategory);
                }
                catch (Exception ex)
                {

                    throw new ServiceException("Error al actualizar categoria.", ex);
                }
            }
        }

        public IEnumerable<Categories> Find (string find)
        {
            string lowerFind = find.ToLower();
            try
            {
               return _logic.Find(lowerFind);
            }
            catch (Exception ex)
            {
                throw new ServiceException("No se ha podido completar la busqueda.", ex);
            }
        }
    }
}
