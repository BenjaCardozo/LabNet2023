using Northwind.Data;
using Northwind.Logic.Application;
using Northwind.MVC.Models;
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
            this._logic = new ShippersLogic();
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
        public ShippersViewModel MapViewModel(Shippers shippers)
        {
            ShippersViewModel shippersView = new ShippersViewModel
            {
                ShipperId = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Phone = shippers.Phone
            };
            return shippersView;
        }
        public Shippers MapDomainModel(ShippersViewModel shippersView)
        {
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
    }
}