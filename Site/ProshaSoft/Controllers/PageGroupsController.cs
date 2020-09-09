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
    public class PageGroupsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PageGroups
        public ActionResult Index()
        {
            return View(db.PageGroups.Where(a=>a.IsDeleted==false).OrderByDescending(a=>a.CreationDate).ToList());
        }

        // GET: PageGroups/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroups.Find(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // GET: PageGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PageGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,TitleEn,UrlParam,IsInHome,Order,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
				pageGroup.IsDeleted=false;
				pageGroup.CreationDate= DateTime.Now; 
                pageGroup.Id = Guid.NewGuid();
                db.PageGroups.Add(pageGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        // GET: PageGroups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroups.Find(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // POST: PageGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,TitleEn,UrlParam,IsInHome,Order,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
				pageGroup.IsDeleted = false;
				pageGroup.LastModifiedDate = DateTime.Now;
                db.Entry(pageGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        // GET: PageGroups/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroups.Find(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // POST: PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PageGroup pageGroup = db.PageGroups.Find(id);
			pageGroup.IsDeleted=true;
			pageGroup.DeletionDate=DateTime.Now;
 
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
