using Northwind.MVC.Models;
using Northwind.MVC.Service;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Northwind.MVC.Controllers
{
    public class PublicApiController : Controller
    {
        private readonly PublicApiService _service;
        public PublicApiController() 
        {
            _service = new PublicApiService();
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                ResultsPersonajesViewModel personajes = await _service.GetAllAsync();
                return View(personajes);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Error");
            }
            
        }

        public async Task<ActionResult> CharacterProfile(int id)
        {
            try
            {
                PersonajesViewModel personaje = await _service.GetByIDAsync(id);
                return View(personaje);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}