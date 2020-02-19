using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CofeWebApplication.Controllers
{
    public class BlogController : ApplicationController
    {
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}