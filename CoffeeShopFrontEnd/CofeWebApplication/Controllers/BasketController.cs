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

namespace CofeWebApplication.Controllers
{
    public class BasketController : ApplicationController
    {
        ////private newcofeshopEntities db = new newcofeshopEntities();
        ////Service1Client basketSrv = new Service1Client();
        Service1Client srv1 = new Service1Client();

        // GET: Basket
        public ActionResult Index(string id)
        {
            var baskets = srv1.GetAllBaskets();
            if (!String.IsNullOrEmpty(id))
            {
                int basketIdInInt = Int32.Parse(id);
                baskets = baskets.Where(s => s.Id == basketIdInInt).ToArray();
                var inBasketItems = srv1.GetTheBasketItems(basketIdInInt);
                var inBasketProduct = srv1.GetAllProduct();
                ViewBag.items = inBasketItems;
                ViewBag.product = inBasketProduct;
                return View(baskets.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Basket/Details/5
        public ActionResult Details(int id)
        {
            var basketItem = srv1.GetAllBasketItems().Where(m => m.BasketItemId == id).FirstOrDefault();
            if (basketItem == null)
            {
                return HttpNotFound();
            }
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
            ViewBag.Basket_Id = new SelectList(srv1.GetAllBaskets(), "Id", "Id", basketItem.Basket_Id);
            ViewBag.Coffee_Id = new SelectList(srv1.GetAllCoffees(), "Id", "Name", basketItem.Product_Id);
            return View(basketItem);
        }

        // POST: BasketItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                int amount_to_change = Int32.Parse(Request.Form["Quantity"]);
                var item = srv1.FindBasketItemById((int)id);
                srv1.EditBasketItem(id, amount_to_change);
                return RedirectToAction("Index",new { id = item.Basket_Id });
            }
            var basketItem = srv1.FindBasketItemById(id);
            ViewBag.Basket_Id = new SelectList(srv1.GetAllBaskets(), "Id", "Id", basketItem.Basket_Id);
            ViewBag.Coffee_Id = new SelectList(srv1.GetAllCoffees(), "Id", "Name", basketItem.Product_Id);
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
            var basketItem = srv1.FindBasketItemById((int)id);
            int basket_id = (int)basketItem.Basket_Id;
            srv1.DeleteFromBasket(basket_id, (int)basketItem.Product_Id);
            return RedirectToAction("Index", new { id = basket_id });
        }

        // GET: BasketItems/Delete/5
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var basket = srv1.FindBasketById((int)id);
            if (basket == null)
            {
                return HttpNotFound();
            }
            return View(basket);
        }

        // POST: BasketItems/Delete/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutConfirmed(int id)
        {
            var basket = srv1.CheckOutBasket(id);
            int new_basket_id = (int)basket.Id;
            Response.Cookies["Basket_id"].Value = new_basket_id.ToString();
            return RedirectToAction("Index", new { id = new_basket_id });
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
