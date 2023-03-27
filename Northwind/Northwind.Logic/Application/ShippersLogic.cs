using Northwind.Data;
using Northwind.Data.Command;
using Northwind.Data.Command.Interface;
using Northwind.Data.Query;
using Northwind.Data.Query.Interface;
using Northwind.Util.Exceptions;
using System;
using System.Collections.Generic;

namespace Northwind.Logic.Application
{
    public class ShippersLogic
    {        
        private IABMGeneric<Shippers> _command;
        private IQueryGeneric<Shippers, int> _query;
        public ShippersLogic() 
        {
            _command = new ABMGeneric<Shippers>();
            _query = new ShippersQuery();
        }
        public ShippersLogic (IABMGeneric<Shippers> command, IQueryGeneric<Shippers, int> query)
        {
            _command = command;
            _query = query;
        }            
            
        public void Add(Shippers newShipper)
        {
            try
            {
                int id = _query.LastID() + 1;
                while (_query.ExistID(id))
                {
                    id = _query.LastID() + 1;
                }
                newShipper.ShipperID = id;

                _command.Add(newShipper);
            }
            catch (Exception)
            {
                throw new MyException("Error al agregar la expedidor.");
            }
        }
        public void Delete(int shipperID)
        {
            try
            {
                Shippers shipperToDelete = _query.GetByID(shipperID);
                if (_query.ExistID(shipperID))
                {
                    _command.Delete(_query.GetByID(shipperID));
                }
                else
                {
                    throw new MyException("El expedidor que desea eliminar no existe.");
                }
            }
            catch (MyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new MyException("Error al eliminar el expedidor.");
            }
        }
        public List<Shippers> GetAll()
        {
            try
            {
                return _query.GetAll();
            }
            catch (Exception)
            {
                throw new MyException("Error al obtener todas los expedidores.");
            }
        }
        public Shippers GetByID(int id)
        {
            try
            {
                return _query.GetByID(id);
            }
            catch (Exception)
            {
                throw new MyException("Error al obtener el expedidor.");
            }
        }
        public void Update(Shippers updateShipper)
        {
            try
            {
                Shippers existingShippers = _query.GetByID(updateShipper.ShipperID);
                if (existingShippers != null)
                {
                    existingShippers.CompanyName = updateShipper.CompanyName;
                    existingShippers.Phone = updateShipper.Phone;
                    _command.Update(existingShippers);
                }
                else
                {
                    throw new MyException("El/la expedidor/expedidora que desea modificar no existe.");
                }
            }
            catch (MyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Shippers> GetByString(string str)
        {
            try
            {
                return _query.GetByString(str);
            }
            catch (Exception)
            {
                throw new MyException("Error al obtener el expedidor por nombre de la compañia.");
            }
        }
    }
}
