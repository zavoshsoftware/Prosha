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
    [Authorize(Roles = "Administrator")]

    public class MapDetailsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: MapDetails
        public ActionResult Index()
        {
            return View(db.MapDetails.Where(a=>a.IsDeleted==false).OrderByDescending(a=>a.CreationDate).ToList());
        }

        // GET: MapDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapDetail mapDetail = db.MapDetails.Find(id);
            if (mapDetail == null)
            {
                return HttpNotFound();
            }
            return View(mapDetail);
        }

        // GET: MapDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MapDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MapDetail mapDetail)
        {
            if (ModelState.IsValid)
            {
				mapDetail.IsDeleted=false;
				mapDetail.CreationDate= DateTime.Now; 
                mapDetail.Id = Guid.NewGuid();
                db.MapDetails.Add(mapDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapDetail);
        }

        // GET: MapDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapDetail mapDetail = db.MapDetails.Find(id);
            if (mapDetail == null)
            {
                return HttpNotFound();
            }
            return View(mapDetail);
        }

        // POST: MapDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MapDetail mapDetail)
        {
            if (ModelState.IsValid)
            {
				mapDetail.IsDeleted = false;
				mapDetail.LastModifiedDate = DateTime.Now;
                db.Entry(mapDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapDetail);
        }

        // GET: MapDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapDetail mapDetail = db.MapDetails.Find(id);
            if (mapDetail == null)
            {
                return HttpNotFound();
            }
            return View(mapDetail);
        }

        // POST: MapDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MapDetail mapDetail = db.MapDetails.Find(id);
			mapDetail.IsDeleted=true;
			mapDetail.DeletionDate=DateTime.Now;
 
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
