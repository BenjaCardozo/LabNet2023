using NorthWindPractica.Data;
using NorthWindPractica.Service.Interface;
using NorthWindPractica.Service.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Logic.Logic
{
    public class TerritoriesService : IABMService<Territories, string>
    {
        private readonly TerritoriesLogic _logic;
        public TerritoriesService() => _logic = new TerritoriesLogic();

        public IEnumerable<Territories> GetAll()
        {
            try
            {
                return _logic.GetAll();
            }
            catch (Exception ex)
            {

                throw new ServiceException("No fue posible listar los territorios.", ex);
            }
        }
        public Territories GetById(string id)
        {
            try
            {
                return _logic.GetById(id);
            }
            catch (Exception)
            {
                throw new ServiceException($"No se pudo conseguir el territorio con id: {id}");
            }
        }
        public void Add(Territories newTerritory)
        {
            string id = _logic.IdGenerator();
            bool existId = _logic.ExistID(id);

            while (existId) { id = _logic.IdGenerator(); }

            try
            {
                newTerritory.TerritoryID = id;
                _logic.Add(newTerritory);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error al agregar un territorio.", ex);
            }
        }
        public void Delete(string id)
        {
            if (_logic.ExistID(id))
            {
                try
                {
                    var deleteTerritory = _logic.GetById(id);
                    _logic.Delete(deleteTerritory);
                }
                catch (Exception ex)
                {
                    throw new ServiceException("Error al eliminar territorio.", ex);
                }
            }
        }
        public void Update(Territories updateTerritory)
        {
            bool existId = _logic.ExistID(updateTerritory.TerritoryID);

            if (existId)
            {
                try
                {
                    _logic.Update(updateTerritory);
                }
                catch (Exception ex)
                {
                    throw new ServiceException("Error al actualizar territorio.", ex);
                }
            }
        }
        public IEnumerable<Territories> Find(string find)
        {
            string lowerFind = find.ToLower();
            try
            {
                return _logic.Find(lowerFind);
            }
            catch (Exception ex)
            {
                throw new ServiceException("No se ha podido realizar la busqueda.", ex);
            }
        }
    }
}
