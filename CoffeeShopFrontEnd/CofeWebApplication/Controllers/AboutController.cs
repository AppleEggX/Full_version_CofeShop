using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CofeWebApplication.Controllers
{
    public class AboutController : ApplicationController
    {
        // GET: About
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}