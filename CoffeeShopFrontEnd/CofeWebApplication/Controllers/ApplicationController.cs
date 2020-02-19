using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CofeWebApplication.ServiceReference1;
using Pocos;
using CofeWebApplication.Models;


namespace CofeWebApplication.Controllers
{
    public abstract class ApplicationController : Controller
    {
        Service1Client srv1 = new Service1Client();
        // GET: Application
        private int currentBasketID;
        public LayoutViewModel layViewModel;

        public ApplicationController()
        {
            ViewBag.BasketItems = new LayoutViewModel();
            ViewBag.Baskets = srv1.GetAllBaskets();
        }
    }
}