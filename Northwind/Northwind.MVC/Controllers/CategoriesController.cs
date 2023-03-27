using Northwind.MVC.Models;
using Northwind.MVC.Service;
using Northwind.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Northwind.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _service;
        public CategoriesController()
        {
            this._service = new CategoriesService();
        }
        public ActionResult Index()
        {
            try
            {
                List<CategoriesViewModel> categoriesViews = _service.GetAll();
                return View(categoriesViews);
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
        public ActionResult Insert(CategoriesViewModel categoriesViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new MyException("No se pudo agregar la categoria.");
                }
                _service.Insert(categoriesViewModel);
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
            CategoriesViewModel categoriesViewModel = _service.GetById(id);
            return View("Insert", categoriesViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoriesViewModel categoriesViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new MyException("Categoria no encontrada");
                }
                _service.Edit(categoriesViewModel);
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
