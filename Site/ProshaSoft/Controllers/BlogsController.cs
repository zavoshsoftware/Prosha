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
using eShopMvc;
using ViewModels;
using Helpers;

namespace ProshaSoft.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BlogsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.Where(a => a.IsDeleted == false).OrderByDescending(a => a.CreationDate).ToList());
        }

        // GET: Blogs/Details/5
        [AllowAnonymous]
        [Route("blog/{urlParam}")]
        public ActionResult Details(string urlParam)
        {
            if (urlParam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.FirstOrDefault(current => current.UrlParam == urlParam);
            if (blog == null)
            {
                return HttpNotFound();
            }

            List<BlogComment> comments = db.BlogComments.Where(current =>
                current.IsActive && current.IsDeleted == false && current.BlogId == blog.Id).ToList();

            BlogDetailViewModel viewModel = new BlogDetailViewModel
            {
                Blog = blog,

                SidebarLatestBlog = db.Blogs.Where(current => current.IsDeleted == false && current.IsActive)
                    .OrderByDescending(current => current.CreationDate).Take(3).ToList(),

                SidebarProducts = db.Products.Where(current => current.IsDeleted == false && current.IsActive)
                    .OrderBy(current => current.Order).ToList(),

                Comments = comments,

                CommentCount = comments.Count,

                RelateBlogs = db.Blogs.Where(current => current.IsRelated && current.IsDeleted == false && current.IsActive)
                    .OrderByDescending(current => current.CreationDate).ToList(),
            };
            ViewBag.HeaderImage = "/assets/images/page-title/title-20.jpg";
            if (!string.IsNullOrEmpty(blog.HeaderImageUrl))
            {
                ViewBag.HeaderImage = blog.HeaderImageUrl;
            }

            blog.Visit = blog.Visit + 1;
            db.SaveChanges();
            return View(viewModel);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.BlogGroupId = new SelectList(db.BlogGroups.Where(x => x.IsDeleted == false && x.IsActive == true).ToList(), "Id", "Title");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog, HttpPostedFileBase fileupload,HttpPostedFileBase fileUpload_header)
        {
            if (ModelState.IsValid)
            {
                blog.Visit = 0;
                #region Upload and resize image if needed
                if (fileupload != null)
                {
                    string newFilenameUrl = string.Empty;
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/Blog/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);

                    string thumbnailUrl = Utils.CreateThumbnail(physicalFilename);
                    blog.ImageUrlThumb = thumbnailUrl;

                    blog.ImageUrl = newFilenameUrl;
                }
                #endregion
                #region Upload and resize image if needed
                if (fileUpload_header != null)
                {
                    string filename = Path.GetFileName(fileUpload_header.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/Blog/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileUpload_header.SaveAs(physicalFilename);

                    blog.HeaderImageUrl = newFilenameUrl;
                }
                #endregion
                blog.IsDeleted = false;
                blog.CreationDate = DateTime.Now;

                blog.Id = Guid.NewGuid();
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogGroupId = new SelectList(db.BlogGroups.Where(x => x.IsDeleted == false && x.IsActive == true).ToList(), "Id", "Title");

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogGroupId = new SelectList(db.BlogGroups.Where(x => x.IsDeleted == false && x.IsActive == true).ToList(), "Id", "Title", blog.BlogGroupId);

            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog, HttpPostedFileBase fileupload,HttpPostedFileBase fileUpload_header)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                if (fileupload != null)
                {
                    string newFilenameUrl = blog.ImageUrl;
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/Blog/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileupload.SaveAs(physicalFilename);
                    string thumbnailUrl = Utils.CreateThumbnail(physicalFilename);
                    blog.ImageUrlThumb = thumbnailUrl;
                    blog.ImageUrl = newFilenameUrl;
                }
                #endregion
                #region Upload and resize image if needed
                if (fileUpload_header != null)
                {
                    string filename = Path.GetFileName(fileUpload_header.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    string newFilenameUrl = "/Uploads/Blog/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);

                    fileUpload_header.SaveAs(physicalFilename);

                    blog.HeaderImageUrl = newFilenameUrl;
                }
                #endregion
                blog.IsDeleted = false;
                blog.LastModifiedDate = DateTime.Now;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogGroupId = new SelectList(db.BlogGroups.Where(x => x.IsDeleted == false && x.IsActive == true).ToList(), "Id", "Title", blog.BlogGroupId);

            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Blog blog = db.Blogs.Find(id);
            blog.IsDeleted = true;
            blog.DeletionDate = DateTime.Now;

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
        [Route("blog")]
        public ActionResult List()
        {
            BlogListViewModel blogs = new BlogListViewModel();
            blogs.Blogs = db.Blogs.Where(current => current.IsDeleted == false && current.IsActive == true).ToList();
            return View(blogs);
        }


    }
}
