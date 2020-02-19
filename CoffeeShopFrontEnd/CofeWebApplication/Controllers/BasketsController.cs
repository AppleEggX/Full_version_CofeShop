using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CofeWebApplication.Models;
using CofeWebApplication.ServiceReference1;
using Pocos;

namespace CofeWebApplication.Controllers
{
    public class BasketsController : ApplicationController
    {
        private Service1Client srv1 = new Service1Client();

        // GET: Baskets
        public ActionResult Index()
        {
            //var baskets = db.Baskets.Include(b => b.User);
            var baskets = srv1.GetAllBaskets();
            return View(baskets.ToList());
        }

        // GET: Baskets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Basket basket = db.Baskets.Find(id);
            var basket = srv1.FindBasketById((int)id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // GET: Baskets/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(/*db.Users*/ srv1.GetAllUser(), "Id", "Name");
            return View();
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SumPrice,User_Id,Paied")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                //db.Baskets.Add(basket);
                //db.SaveChanges();
                srv1.CreateBasket(basket);
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(/*db.Users*/ srv1.GetAllUser(), "Id", "Name", basket.User.Id);
            return View(basket);
        }

        // GET: Baskets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Basket basket = db.Baskets.Find(id);
            var basket = srv1.FindBasketById((int)id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(/*db.Users*/ srv1.GetAllUser(), "Id", "Name", basket.User_Id);
            return View(basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SumPrice,User_Id,Paied")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(basket).State = EntityState.Modified;
                //db.SaveChanges();
                srv1.UpdateBasket(basket);
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(/*db.Users*/ srv1.GetAllUser(), "Id", "Name", basket.User.Id);
            return View(basket);
        }

        // GET: Baskets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Basket basket = db.Baskets.Find(id);
            var basket = srv1.FindBasketById((int)id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }
        

        // POST: Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Basket basket = db.Baskets.Find(id);
            //db.Baskets.Remove(basket);
            //db.SaveChanges();
            var basket = srv1.FindBasketById(id);
            srv1.DeleteBasket(id);
            return RedirectToAction("Index");
        }

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
