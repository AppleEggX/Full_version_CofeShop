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
    public class BasketItemsController : ApplicationController
    {
        Service1Client srv1 = new Service1Client();
        // GET: BasketItems
        public ActionResult Index()
        {
            var basketItems = srv1.GetAllBasketItems();
            return View(basketItems.ToList());
        }

        // GET: BasketItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var basketItem = srv1.FindBasketItemById((int)id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        // GET: BasketItems/Create
        public ActionResult Create()
        {
            ViewBag.Basket_Id = new SelectList(/*db.Baskets*/ srv1.GetAllBaskets(), "Id", "Id");
            ViewBag.Coffee_Id = new SelectList(/*db.Coffees*/ srv1.GetAllCoffees(), "Id", "Name");
            return View();
        }

        // POST: BasketItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BasketItemId,Quantity,TotalPrice,Basket_Id,Coffee_Id")] BasketItem basketItem)
        {
            if (ModelState.IsValid)
            {
                srv1.CreateBasketItem(basketItem);
                return RedirectToAction("Index");
            }

            ViewBag.Basket_Id = new SelectList(/*db.Baskets*/ srv1.GetAllBaskets(), "Id", "Id", basketItem.Basket.Id);
            ViewBag.Coffee_Id = new SelectList(/*db.Coffees*/ srv1.GetAllCoffees(), "Id", "Name", basketItem.Product.Id);
            return View(basketItem);
        }

        // GET: BasketItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var basketItem = srv1.FindBasketItemById((int)id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Basket_Id = new SelectList(/*db.Baskets*/ srv1.GetAllBaskets(), "Id", "Id", basketItem.Basket_Id);
            ViewBag.Coffee_Id = new SelectList(/*db.Coffees*/ srv1.GetAllCoffees(), "Id", "Name", basketItem.Product_Id);
            return View(basketItem);
        }

        // POST: BasketItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,TotalPrice,Basket_Id,Coffee_Id")] BasketItem basketItem)
        {
            if (ModelState.IsValid)
            {
                srv1.UpdateBasketItem(basketItem);
                return RedirectToAction("Index");
            }
            ViewBag.Basket_Id = new SelectList(/*db.Baskets*/ srv1.GetAllBaskets(), "Id", "Id", basketItem.Basket.Id);
            ViewBag.Coffee_Id = new SelectList(/*db.Coffees*/ srv1.GetAllCoffees(), "Id", "Name", basketItem.Product.Id);
            return View(basketItem);
        }

        // GET: BasketItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var basketItem = srv1.FindBasketItemById((int)id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        // POST: BasketItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var basketitem = srv1.FindBasketItemById(id);
            srv1.DeleteBasketItem(id);
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
