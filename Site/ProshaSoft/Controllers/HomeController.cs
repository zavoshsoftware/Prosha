using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModels;

namespace ProshaSoft.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            Guid featuresId = new Guid("c0267e80-3592-45de-b807-793ef4521f50");
            Guid numberId = new Guid("8716ba57-69c0-42ec-b032-37929f98ec3d");
            HomeViewModel home = new HomeViewModel()
            {
                MapDetails = db.MapDetails.Where(c => c.IsActive && c.IsDeleted == false).ToList(),
                Sliders = db.Sliders.Where(c => c.IsActive && c.IsDeleted == false).OrderBy(c => c.Order).ToList(),
                About = db.TextTypeItems.Where(c => c.Name == "homeabout" && c.IsActive).FirstOrDefault(),
                FeaturesTexts = db.TextTypeItems.Where(c => c.TextTypeId == featuresId && c.IsActive).ToList(),
                FeaturImage = db.TextTypeItems.Where(c => c.Name == "featureimage" && c.IsActive).FirstOrDefault(),
                MapDescription = db.TextTypeItems.Where(c => c.Name == "homeMapDesc" && c.IsActive).FirstOrDefault(),
                PosInfo = db.TextTypeItems.Where(c => c.Name == "pos-detail" && c.IsActive).FirstOrDefault(),
                MiniSliders = db.MiniSliders.Where(c => c.IsActive && c.IsDeleted == false && c.Type == false).ToList(),
                DesktopSliders = db.MiniSliders.Where(c => c.IsActive && c.IsDeleted == false && c.Type == true).ToList(),
                Costumers = db.Costumers.Where(c => c.IsActive && c.IsDeleted == false).ToList(),
                Numbers = db.TextTypeItems.Where(c => c.TextTypeId == numberId && c.IsActive).ToList(),
                LatestBlogs = db.Blogs.Where(c => c.IsActive && c.IsDeleted == false).OrderByDescending(c => c.CreationDate).Take(5).ToList(),
            };
            return View(home);
        }
        public ActionResult ProductDetail()
        {
            HomeViewModel home = new HomeViewModel();
            return View(home);
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ContactViewModel contact = new ContactViewModel()
            {
                Address = db.TextTypeItems.FirstOrDefault(c => c.Name == "address").BodySrt,
                Phone = db.TextTypeItems.FirstOrDefault(c => c.Name == "phone").BodySrt,
                WorkTime = db.TextTypeItems.FirstOrDefault(c => c.Name == "worktime").BodySrt,
                Email = db.TextTypeItems.FirstOrDefault(c => c.Name == "email").BodySrt,
            };

            return View(contact);
        }

        [Route("about")]
        public ActionResult About()
        {
            Guid middleBanner = new Guid("0f382159-eab4-4550-831c-9a25b29ceb40");
            Guid mission = new Guid("5f2212b8-19cd-4385-aec8-74cb5eda71b8");
            Guid history = new Guid("947c72e0-b184-4667-8b95-09e282b47688");

            AboutViewModel about = new AboutViewModel();
            about.Aboutus = db.TextTypeItems.Where(current => current.Name == "AboutUs").FirstOrDefault();
            about.HistoryTexts = db.TextTypeItems.Where(current => current.TextTypeId == history).OrderBy(c=>c.Title).ToList();
            about.StartWithProsha = db.TextTypeItems.Where(current => current.Name == "startedposprocess").FirstOrDefault();
            about.MiddleBanner = db.TextTypeItems.Where(current => current.TextTypeId == middleBanner).ToList();
            about.Missions = db.TextTypeItems.Where(current => current.TextTypeId == mission).OrderBy(x => x.CreationDate).ToList();

            return View(about);
        }

    }
}