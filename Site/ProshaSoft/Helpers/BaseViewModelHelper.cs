using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;
using ViewModels;

//using ViewModels;

namespace Helpers
{
    public class BaseViewModelHelper
    {
        private DatabaseContext db = new DatabaseContext();

        public List<Product> GetMenuProductGroup()
        {
            return db.Products.Where(c => c.IsDeleted == false && c.IsActive).OrderBy(c => c.Order).ToList();
        }

        public string GetAddress()
        {
            return db.TextTypeItems.FirstOrDefault(c => c.Name == "address").BodySrt;
        }
        public string GetPhone()
        {
            return db.TextTypeItems.FirstOrDefault(c => c.Name == "phone").BodySrt;
        }
        public string GetEmail()
        {
            return db.TextTypeItems.FirstOrDefault(c => c.Name == "email").BodySrt;
        }
        public string GetFooterAbout()
        {
            return db.TextTypeItems.FirstOrDefault(c => c.Name == "footerAbout").BodySrt;
        }
        public TextTypeItem GetWhatsappInfo()
        {
            return db.TextTypeItems.FirstOrDefault(c => c.Name == "whatsapp");
        }

        public List<TextTypeItem> GetSocial()
        {
            return db.TextTypeItems.Where(c => c.TextType.Title.ToLower() == "sociallink").ToList();
        }
        public List<TextTypeItem> GetSupportLinks()
        {
            return db.TextTypeItems.Where(c => c.TextType.Title.ToLower() == "support").ToList();
        }
        public List<Blog> GetFooterLatestBlogs()
        {
            return db.Blogs.Where(current => current.IsDeleted == false && current.IsActive)
                .OrderByDescending(current => current.CreationDate).Take(3).ToList();
        }

        public List<PageGroupsMenu> GetPageGroups()
        {
            List<PageGroupsMenu> result = new List<PageGroupsMenu>();
            List<PageGroup> pageGroups = db.PageGroups.Where(current => current.IsInHome == true && current.IsDeleted == false && current.IsActive == true).ToList();
            foreach (var item in pageGroups)
            {
                result.Add(new PageGroupsMenu()
                {
                    PageGroup = item,
                    Pages = db.Pages.Where(current => current.IsDeleted == false && current.IsActive == true &&
                    current.PageGroupId == item.Id).ToList()
                });
            }
            return result;
        }
        public List<Page> GetPages()
        {
            return db.Pages.Where(current => current.IsDeleted == false && current.IsActive == true &&
                    current.PageGroupId == null).ToList();
        }
    }
}