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
    public class RegionService : IABMService<Region, int>
    {
        private readonly RegionLogic _logic;
        public RegionService()=> _logic = new RegionLogic();

        public IEnumerable<Region> GetAll()
        {
            try
            {
                return _logic.GetAll();
            }
            catch (Exception ex)
            {
                throw new ServiceException("No ha sido posible listar las regiones.", ex);
            }
        }
        public Region GetById(int id)
        {
            try
            {
                return _logic.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("No se ha podido obtener la region.", ex);
            }
        }
        public IEnumerable<Region> Find(string find)
        {
            try
            {
                string lowerFind = find.ToLower();
                return _logic.Find(lowerFind);
            }
            catch (Exception ex)
            {
                throw new ServiceException("No hubo resultados", ex);
            }
        }
        public void Add(Region newRegion)
        {
            try
            {
                _logic.Add(newRegion);
            }
            catch (Exception ex)
            {

                throw new ServiceException("No se pudo agregar la region.", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                bool existID = _logic.ExistID(id);                
                if (existID)
                {
                    Region regionDelete = _logic.GetById(id);
                    _logic.Delete(regionDelete);
                }
            }
            catch (Exception ex)
            {
                throw new ServiceException("No se pudo eliminar la region.", ex);
            }
        }        
        public void Update(Region updateClass)
        {
            throw new NotImplementedException();
        }
    }
}
