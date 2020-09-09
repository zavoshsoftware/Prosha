using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using System.IO;

namespace ProshaSoft.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CostumersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Costumers
        public ActionResult Index()
        {
            return View(db.Costumers.Where(a=>a.IsDeleted==false).OrderByDescending(a=>a.CreationDate).ToList());
        }

        // GET: Costumers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = db.Costumers.Find(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // GET: Costumers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Costumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Costumer costumer,HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                string newFilenameUrl = string.Empty;
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/costumer/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    costumer.ImageUrl = newFilenameUrl;
                }
                #endregion
                costumer.IsDeleted=false;
				costumer.CreationDate= DateTime.Now; 
                costumer.Id = Guid.NewGuid();
                db.Costumers.Add(costumer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costumer);
        }

        // GET: Costumers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = db.Costumers.Find(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // POST: Costumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Costumer costumer,HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                string newFilenameUrl = string.Empty;
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/costumer/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    costumer.ImageUrl = newFilenameUrl;
                }
                #endregion
                costumer.IsDeleted = false;
				costumer.LastModifiedDate = DateTime.Now;
                db.Entry(costumer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costumer);
        }

        // GET: Costumers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = db.Costumers.Find(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // POST: Costumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Costumer costumer = db.Costumers.Find(id);
			costumer.IsDeleted=true;
			costumer.DeletionDate=DateTime.Now;
 
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
