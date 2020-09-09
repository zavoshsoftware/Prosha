using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace TopCasterone.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class ProductFeaturesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index(Guid id)
        {
            var productFeatures = db.ProductFeatures.Include(p => p.Product).Where(p=>p.ProductId==id&& p.IsDeleted==false).OrderByDescending(p=>p.CreationDate);
            return View(productFeatures.ToList());
        }

        public ActionResult Create(Guid id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductFeature productFeature,Guid id)
        {
            if (ModelState.IsValid)
            {
                productFeature.ProductId = id;
				productFeature.IsDeleted=false;
				productFeature.CreationDate= DateTime.Now; 
                productFeature.Id = Guid.NewGuid();
                productFeature.Code = ReturnCode();
                db.ProductFeatures.Add(productFeature);
                db.SaveChanges();
                return RedirectToAction("Index",new {id=id});
            }

            ViewBag.ProductId = id;
            return View(productFeature);
        }
        public int ReturnCode()
        {

            ProductFeature productfeature = db.ProductFeatures.OrderByDescending(current => current.Code).FirstOrDefault();
            if (productfeature != null)
            {
                return productfeature.Code + 1;
            }
            else
            {
                return 1;
            }
        }
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeatures.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId =   productFeature.ProductId;
            return View(productFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductFeature productFeature)
        {
            if (ModelState.IsValid)
            {
				productFeature.IsDeleted = false;
				productFeature.LastModifiedDate = DateTime.Now;
                db.Entry(productFeature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = productFeature.ProductId;
            return RedirectToAction("Index", new { id = productFeature.ProductId });
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeatures.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = productFeature.ProductId;

            return View(productFeature);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductFeature productFeature = db.ProductFeatures.Find(id);
			productFeature.IsDeleted=true;
			productFeature.DeletionDate=DateTime.Now;
 
            db.SaveChanges();
            return RedirectToAction("Index", new { id = productFeature.ProductId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void CreateData()
        {
            List<Product> products = db.Products.ToList();
            foreach (Product product in products)
            {
                InsertToTable(product.Id, "ساخت", "ایتالیا");
                InsertToTable(product.Id, "اندازه", "3 mm");
                InsertToTable(product.Id, "جنس", "آلمینیوم");
            }
        }

        public void InsertToTable(Guid productId,string key,string value)
        {

            ProductFeature productFeature = new ProductFeature()
            {
                Id = Guid.NewGuid(),
                Key = key,
                Value = value,
                IsDeleted = false,
                IsActive = true,
                CreationDate = DateTime.Now,
                ProductId = productId,
            };

            db.ProductFeatures.Add(productFeature);
            db.SaveChanges();
        }
    }
}
