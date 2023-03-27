using Northwind.MVC.Models;
using Northwind.MVC.Service;
using Northwind.Util.Exceptions;
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
            _service = new ShippersService();
        }

        public ActionResult Index()
        {
            try
            {
                List<ShippersViewModel> shippersView = _service.GetAll();
                return View(shippersView);
            }
            catch (MyException ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
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
                    throw new MyException("No se pudo agregar el expedidor.");
                }
                _service.Insert(shippersView);
                return RedirectToAction("Index");
            }
            catch (MyException ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
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
                    throw new MyException("No se pudo editar el expedidor.");
                }
            _service.Edit(shipperViewModel);
            return RedirectToAction("Index");

            }
            catch (MyException ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
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
            catch (MyException ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ha ocurrido un error" + ex.Message;
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
