using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CofeWebApplication.Models;
using CofeWebApplication.ServiceReference1;
using Pocos;

namespace CofeWebApplication.Controllers
{
    public class CoffeesController : ApplicationController
    {
        Service1Client srv1 = new Service1Client();

        // GET: Coffees
        [AllowAnonymous]
        public ActionResult Index(string coffeeType, string searchName)
        {
            var TypeList = new List<string>();
            var TypeQry = from d in /*db.Coffees*/ srv1.GetAllCoffees()
                          orderby d.CoffeeType.ToString()
                          select d.CoffeeType.ToString();
            TypeList.AddRange(TypeQry.Distinct());
            ViewBag.coffeeType = new SelectList(TypeList);

            var coffees = from c in srv1.GetAllCoffees() select c;
            if (!String.IsNullOrEmpty(searchName))
            {
                coffees = coffees.Where(s => s.Name.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(coffeeType))
            {
                coffees = coffees.Where(x => x.CoffeeType.ToString() == coffeeType);
            }
            return View(coffees);
        }
        [AllowAnonymous]
        // GET: Coffees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var coffee = srv1.FindCoffeeById((int)id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // GET: Coffees/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coffees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Origin,Type,Rating,TastingNote,Story,Storage,Price")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                srv1.CreateCoffee(coffee);
                return RedirectToAction("Index");
            }

            return View(coffee);
        }

        // GET: Coffees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var coffee = srv1.FindCoffeeById((int)id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Origin,CoffeeType,Rating,Strength,Description,Stock,Price")] CoffeeDTO newcoffee)
        {
            if (ModelState.IsValid)
            {
                Coffee coffee = new Coffee
                {
                    Id = newcoffee.Id,
                    Name = newcoffee.Name,
                    Origin = newcoffee.Origin,
                    CoffeeType = newcoffee.CoffeeType,
                    Rating = newcoffee.Rating,
                    Strength = newcoffee.Strength,
                    Description = newcoffee.Description,
                    Price = newcoffee.Price,
                    Stock = newcoffee.Stock,
                    Type = newcoffee.Type
                };
                srv1.UpdateCoffee(coffee);
                return RedirectToAction("Index");
            }
            return View(newcoffee);
        }

        // GET: Coffees/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var coffee = srv1.FindCoffeeById((int)id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var coffee = srv1.FindCoffeeById(id);
            srv1.DeleteCoffee(id);
            return RedirectToAction("Index");
        }

        #region Adding to basket 
        // Get: Coffees/AddToBasket
        public ActionResult AddToBasket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var coffee = srv1.FindCoffeeById((int)id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            ViewBag.coffeeInfo = coffee;
            var itemToAdd = new CoffeeViewModel()
            {
                Name = coffee.Name,
                Price = coffee.Price,
                Quantity = 1
            };
            return View(itemToAdd);
        }

        // POST: Coffees/AddToBasket/5
        [HttpPost, ActionName("AddToBasket")]
        [ValidateAntiForgeryToken]
        public ActionResult AddToBasketConfirmed(int id)
        {
            int thisBasketId;
            int itemAmount = Int32.Parse(Request.Form["Quantity"]);
            if (Request.Cookies["Basket_id"] != null)
            {
                string bi = Request.Cookies["Basket_id"].Value;
                thisBasketId = Int32.Parse(bi);
            }
            else
            {
                thisBasketId = 1;
            }
            srv1.AddtoBasket(thisBasketId, (int)id, (int)itemAmount);
            return RedirectToAction("Index","Basket",new { id = (int)thisBasketId });
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
