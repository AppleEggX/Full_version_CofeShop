using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using CofeWebApplication.ServiceReference1;
using CofeWebApplication.Models;
using Pocos;

namespace CofeWebApplication.Controllers
{
    public class CoursesController : ApplicationController
    {
        Service1Client srv1 = new Service1Client();
        // GET: Courses
        [AllowAnonymous]
        public ActionResult Index(string difficulty, string searchName)
        {
            var TypeList = new List<string>();
            var TypeQry = from d in srv1.GetAllCourses()
                          orderby d.Difficulty.ToString()
                          select d.Difficulty.ToString();
            TypeList.AddRange(TypeQry.Distinct());
            ViewBag.Difficulty = new SelectList(TypeList);

            var course = from c in srv1.GetAllCourses() select c;
            if (!String.IsNullOrEmpty(searchName))
            {
                course = course.Where(s => s.Name.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(difficulty))
            {
                course = course.Where(x => x.Difficulty.ToString() == difficulty);
            }
            return View(course);
        }

        [AllowAnonymous]
        // GET: Coffees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var course = srv1.FindCourseById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
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
        public ActionResult Create([Bind(Include = "Id,Name,Description,Length,Rating,Difficulty,AvailableStartDates,CourseType,Price")] Course course)
        {
            if (ModelState.IsValid)
            {
                srv1.CreateCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Coffees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var course = srv1.FindCourseById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Length,Rating,Difficulty,AvailableStartDates,CourseType,Price")] Course course)
        {
            if (ModelState.IsValid)
            {
                srv1.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Coffees/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = srv1.FindCourseById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            srv1.DeleteCourse(id);
            return RedirectToAction("Index");
        }

        #region Adding to basket 
        // Get: Courses/AddToBasket
        public ActionResult AddToBasket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = srv1.FindCourseById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseInfo = course;
            var itemToAdd = new CourseViewModels
            {
                Name = course.Name,
                Price = course.Price,
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
            return RedirectToAction("Index", "Basket", new { id = (int)thisBasketId });
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