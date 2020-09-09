using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace ProshaSoft.Controllers
{
    public class ProductCountersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ProductCounters
        public ActionResult Index()
        {
            var productCounters = db.ProductCounters.Include(p => p.Product).Where(p=>p.IsDeleted==false).OrderByDescending(p=>p.CreationDate);
            return View(productCounters.ToList());
        }

        // GET: ProductCounters/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCounter productCounter = db.ProductCounters.Find(id);
            if (productCounter == null)
            {
                return HttpNotFound();
            }
            return View(productCounter);
        }

        // GET: ProductCounters/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title");
            return View();
        }

        // POST: ProductCounters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Key,KeyEN,Value,ValueEN,ProductId,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] ProductCounter productCounter)
        {
            if (ModelState.IsValid)
            {
				productCounter.IsDeleted=false;
				productCounter.CreationDate= DateTime.Now; 
                productCounter.Id = Guid.NewGuid();
                db.ProductCounters.Add(productCounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", productCounter.ProductId);
            return View(productCounter);
        }

        // GET: ProductCounters/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCounter productCounter = db.ProductCounters.Find(id);
            if (productCounter == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", productCounter.ProductId);
            return View(productCounter);
        }

        // POST: ProductCounters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Key,KeyEN,Value,ValueEN,ProductId,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] ProductCounter productCounter)
        {
            if (ModelState.IsValid)
            {
				productCounter.IsDeleted = false;
				productCounter.LastModifiedDate = DateTime.Now;
                db.Entry(productCounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", productCounter.ProductId);
            return View(productCounter);
        }

        // GET: ProductCounters/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCounter productCounter = db.ProductCounters.Find(id);
            if (productCounter == null)
            {
                return HttpNotFound();
            }
            return View(productCounter);
        }

        // POST: ProductCounters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductCounter productCounter = db.ProductCounters.Find(id);
			productCounter.IsDeleted=true;
			productCounter.DeletionDate=DateTime.Now;
 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
