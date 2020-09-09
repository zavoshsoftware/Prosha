using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace ProshaSoft.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class MiniSlidersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: MiniSliders
        public ActionResult Index()
        {
            return View(db.MiniSliders.Where(a=>a.IsDeleted==false).OrderByDescending(a=>a.CreationDate).ToList());
        }

        // GET: MiniSliders/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniSlider miniSlider = db.MiniSliders.Find(id);
            if (miniSlider == null)
            {
                return HttpNotFound();
            }
            return View(miniSlider);
        }

        // GET: MiniSliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiniSliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MiniSlider miniSlider, HttpPostedFileBase fileupload)
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

                    newFilenameUrl = "/Uploads/Slider/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    miniSlider.ImageUrl = newFilenameUrl;
                }
                #endregion
                miniSlider.IsDeleted=false;
				miniSlider.CreationDate= DateTime.Now; 
                miniSlider.Id = Guid.NewGuid();
                db.MiniSliders.Add(miniSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miniSlider);
        }

        // GET: MiniSliders/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniSlider miniSlider = db.MiniSliders.Find(id);
            if (miniSlider == null)
            {
                return HttpNotFound();
            }
            return View(miniSlider);
        }

        // POST: MiniSliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MiniSlider miniSlider, HttpPostedFileBase fileupload)
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

                    newFilenameUrl = "/Uploads/Slider/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    miniSlider.ImageUrl = newFilenameUrl;
                }
                #endregion
                miniSlider.IsDeleted = false;
				miniSlider.LastModifiedDate = DateTime.Now;
                db.Entry(miniSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miniSlider);
        }

        // GET: MiniSliders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniSlider miniSlider = db.MiniSliders.Find(id);
            if (miniSlider == null)
            {
                return HttpNotFound();
            }
            return View(miniSlider);
        }

        // POST: MiniSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MiniSlider miniSlider = db.MiniSliders.Find(id);
			miniSlider.IsDeleted=true;
			miniSlider.DeletionDate=DateTime.Now;
 
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
