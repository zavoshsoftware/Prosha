using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Models;
using Telerik.Windows.Documents.Flow.Model;

namespace ProshaSoft.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductCommentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ProductComments
        public ActionResult Index()
        {
            var productComments = db.ProductComments.Include(p => p.Product).Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreationDate);
            return View(productComments.ToList());
        }

        // GET: ProductComments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductComment productComment = db.ProductComments.Find(id);
            if (productComment == null)
            {
                return HttpNotFound();
            }
            return View(productComment);
        }

        // GET: ProductComments/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title");
            return View();
        }

        // POST: ProductComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductComment productComment)
        {
            if (ModelState.IsValid)
            {
                productComment.IsDeleted = false;
                productComment.CreationDate = DateTime.Now;
                productComment.Id = Guid.NewGuid();
                db.ProductComments.Add(productComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", productComment.ProductId);
            return View(productComment);
        }

        // GET: ProductComments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductComment productComment = db.ProductComments.Find(id);
            if (productComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", productComment.ProductId);
            return View(productComment);
        }

        // POST: ProductComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductComment productComment)
        {
            if (ModelState.IsValid)
            {
                productComment.IsDeleted = false;
                productComment.LastModifiedDate = DateTime.Now;
                db.Entry(productComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", productComment.ProductId);
            return View(productComment);
        }

        // GET: ProductComments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductComment productComment = db.ProductComments.Find(id);
            if (productComment == null)
            {
                return HttpNotFound();
            }
            return View(productComment);
        }

        // POST: ProductComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductComment productComment = db.ProductComments.Find(id);
            productComment.IsDeleted = true;
            productComment.DeletionDate = DateTime.Now;

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


        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostSubmitComment(string name, string email, string body, string id)
        {
            try
            {
                bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                if (!isEmail)
                    return Json("InvalidEmail", JsonRequestBehavior.AllowGet);

                int productCode = Convert.ToInt32(id);

                Product product= db.Products.FirstOrDefault(c => c.Code == productCode&&c.IsDeleted==false);

                if(product==null)
                    return Json("false", JsonRequestBehavior.AllowGet);

                ProductComment comment = new ProductComment();

                comment.Name = name;
                comment.Email = email;
                comment.Message = body;
                comment.CreationDate = DateTime.Now;
                comment.IsDeleted = false;
                comment.Id = Guid.NewGuid();
                comment.ProductId = product.Id;
                comment.IsActive = false;
                comment.CreationDate = DateTime.Now;


                db.ProductComments.Add(comment);
                db.SaveChanges();
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

    }
}
