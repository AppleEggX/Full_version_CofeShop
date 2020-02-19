using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CofeWebApplication.ServiceReference1;

namespace CofeWebApplication.Controllers
{
    public class HomeController : ApplicationController
    {
        private Service1Client srv1 = new Service1Client();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var coffees = from c in srv1.GetAllCoffees() select c;
            return View(coffees);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "This is the websit to select Coffees.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Here is the contact details.";

            return View();
        }
    }
}