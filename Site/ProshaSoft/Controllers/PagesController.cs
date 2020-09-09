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
using ViewModels;

namespace ProshaSoft.Controllers
{
    public class PagesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Pages
        public ActionResult Index()
        {
            var pages = db.Pages.Include(p => p.PageGroup).Where(p=>p.IsDeleted==false).OrderByDescending(p=>p.CreationDate);
            return View(pages.ToList());
        }

        // GET: Pages/Details/5
        [Route("page/{urlParam}")]
        public ActionResult Details(string urlParam)
        {
            if (urlParam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Where(current=>current.UrlParam== urlParam&&current.IsDeleted==false&&current.IsActive==true).FirstOrDefault();
            if (page == null)
            {
                return HttpNotFound();
            }
            PageDetailsViewModel pageDetails = new PageDetailsViewModel()
            {
                Page = page
            };
            ViewBag.HeaderImage = "/assets/images/page-title/title-20.jpg";
            if (!string.IsNullOrEmpty(page.HeaderImageUrl))
            {
                ViewBag.HeaderImage = page.HeaderImageUrl;
            }
            return View(pageDetails);
        }

        // GET: Pages/Create
        public ActionResult Create()
        {
            ViewBag.PageGroupId = new SelectList(db.PageGroups, "Id", "Title");
            return View();
        }

        // POST: Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Page page,HttpPostedFileBase fileupload,HttpPostedFileBase fileUploadHeader)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/Page/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    page.ImageUrl = newFilenameUrl;
                }
                #endregion
                #region Upload and resize image if needed
                if (fileUploadHeader != null)
                {
                    string filename = Path.GetFileName(fileUploadHeader.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/Page/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileUploadHeader.SaveAs(physicalFilename);

                    page.HeaderImageUrl = newFilenameUrl;
                }
                #endregion
                page.IsDeleted=false;
				page.CreationDate= DateTime.Now; 
                page.Id = Guid.NewGuid();
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageGroupId = new SelectList(db.PageGroups, "Id", "Title", page.PageGroupId);
            return View(page);
        }

        // GET: Pages/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageGroupId = new SelectList(db.PageGroups, "Id", "Title", page.PageGroupId);
            return View(page);
        }

        // POST: Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Page page,HttpPostedFileBase fileupload,HttpPostedFileBase fileUploadHeader)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/Page/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    page.ImageUrl = newFilenameUrl;
                }
                #endregion
                #region Upload and resize image if needed
                if (fileUploadHeader != null)
                {
                    string filename = Path.GetFileName(fileUploadHeader.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/Page/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileUploadHeader.SaveAs(physicalFilename);

                    page.HeaderImageUrl = newFilenameUrl;
                }
                #endregion
                page.IsDeleted = false;
				page.LastModifiedDate = DateTime.Now;
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageGroupId = new SelectList(db.PageGroups, "Id", "Title", page.PageGroupId);
            return View(page);
        }

        // GET: Pages/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Page page = db.Pages.Find(id);
			page.IsDeleted=true;
			page.DeletionDate=DateTime.Now;
 
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
