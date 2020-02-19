using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CofeWebApplication.Controllers
{
    public class WishlistController : ApplicationController
    {
        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }
    }
}