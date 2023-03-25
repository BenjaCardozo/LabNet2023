using Northwind.MVC.Models;
using Northwind.MVC.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Northwind.MVC.Controllers
{
    public class ShippersController : Controller
    {
        private readonly ShippersService _service;
        public ShippersController()
        {
            this._service = new ShippersService();
        }

        public ActionResult Index()
        {
            try
            {
                List<ShippersViewModel> shippersView = _service.GetAll();
                return View(shippersView);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Error");
            }            
        }

        public ActionResult Insert()
        {
            return View("Insert");
        }

        [HttpPost]
        public ActionResult Insert(ShippersViewModel shippersView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(shippersView);
                }
                _service.Insert(shippersView);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
                
        }

        public ActionResult Edit(int id)
        {
            ShippersViewModel shipperViewModel = _service.GetById(id);
            return View("Insert",shipperViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShippersViewModel shipperViewModel)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return View("Insert",shipperViewModel);
            }
            _service.Edit(shipperViewModel);
            return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Content("1");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
