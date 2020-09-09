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
    public class TextTypeItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TextTypeItems
        public ActionResult Index(Guid id)
        {
            var textItems = db.TextTypeItems.Include(t => t.TextType).Where(t => t.IsDeleted == false && t.TextTypeId == id).OrderByDescending(t => t.CreationDate);
            return View(textItems.ToList());
        }
        [AllowAnonymous]
        public ActionResult Create(Guid id)
        {
            ViewBag.fk = id;
            ViewBag.TextTypeId = new SelectList(db.TextTypes.Where(current => current.IsDeleted == false && current.IsActive == true).ToList(),"Id","Title");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(TextTypeItem textTypeItem,Guid id)
        {
            if (ModelState.IsValid)
            {
                textTypeItem.IsDeleted = false;
                textTypeItem.CreationDate = DateTime.Now;

                textTypeItem.Id = Guid.NewGuid();
                textTypeItem.TextTypeId = id;
                db.TextTypeItems.Add(textTypeItem);
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = textTypeItem.TextTypeId });
            }
            ViewBag.fk = id;
            ViewBag.TextTypeId = new SelectList(db.TextTypes.Where(current => current.IsDeleted == false && current.IsActive == true).ToList(), "Id", "Title");
            return View(textTypeItem);
        }


        // GET: TextItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextTypeItem textItems = db.TextTypeItems.Find(id);
            if (textItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk = textItems.TextTypeId;
            return View(textItems);
        }

        // POST: TextItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TextTypeItem textItems, HttpPostedFileBase fileupload)
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
                    newFilenameUrl = "/Uploads/Text/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    textItems.ImageUrl = newFilenameUrl;
                }

                #endregion
                textItems.LastModifiedDate = DateTime.Now;
                textItems.IsDeleted = false;
                db.Entry(textItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = textItems.TextTypeId });
            }
            return View(textItems);
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
