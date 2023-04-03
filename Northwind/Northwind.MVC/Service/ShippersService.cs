using Northwind.Data;
using Northwind.Logic.Application;
using Northwind.MVC.Models;
using Northwind.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.MVC.Service
{
    public class ShippersService
    {
        private readonly ShippersLogic _logic;
        public ShippersService() 
        {
            _logic = new ShippersLogic();
        }
        public List<ShippersViewModel> GetAll()
        {
            try
            {
                return _logic.GetAll().Select(shipper => MapViewModel(shipper)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ShippersViewModel GetById(int id) 
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
        public void Insert(ShippersViewModel shippersView)
        {
            try
            {
                _logic.Add(MapDomainModel(shippersView));
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
        public void Edit(ShippersViewModel shippersView)
        {
            try
            {
                _logic.Update(MapDomainModel(shippersView));
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
        public void Delete(int id)
        {
            try
            {
                _logic.Delete(id);
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
        public ShippersViewModel MapViewModel(Shippers shippers)
        {
            try
            {
                if (shippers == null)
                {
                    throw new MyException("El expedidor esta vacío o no existe.");
                }
                ShippersViewModel shippersView = new ShippersViewModel
                {
                    ShipperId = shippers.ShipperID,
                    CompanyName = shippers.CompanyName,
                    Phone = shippers.Phone
                };
                return shippersView;
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
        public Shippers MapDomainModel(ShippersViewModel shippersView)
        {
            try
            {
                if (shippersView == null)
                {
                    throw new MyException("El expedidor esta vacío o no existe");
                }
                Shippers shippers = new Shippers();

                if (shippersView.ShipperId == null)
                {
                    shippers.ShipperID = _logic.GetAll().Select(s => s.ShipperID).Last();
                }
                else
                {
                   shippers.ShipperID = (int)shippersView.ShipperId;
                }            
                shippers.CompanyName = shippersView.CompanyName;
                shippers.Phone = shippersView.Phone;
                return shippers;
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
    }
}