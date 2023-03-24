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
        // GET: Shippers
        public ActionResult Index()
        {
            try
            {
                List<ShippersViewModel> shippersView = _service.GetAll();
                return View(shippersView);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Error");
            }
            
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View("Insert");
        }

        // POST: Shippers/Create
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

        // GET: Shippers/Edit/5
        public ActionResult Edit(int id)
        {
            ShippersViewModel shipperViewModel = _service.GetById(id);
            return View("Insert",shipperViewModel);
        }

        // POST: Shippers/Edit/5
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

        // GET: Shippers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shippers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
