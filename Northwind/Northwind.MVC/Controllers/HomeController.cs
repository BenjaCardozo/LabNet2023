﻿using System.Web.Mvc;

namespace Northwind.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}