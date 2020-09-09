using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers;
using Models;

namespace  ViewModels
{
    public class _BaseViewModel
    {
        readonly BaseViewModelHelper _baseViewModelHelper = new BaseViewModelHelper();
        public List<Product> MenuProducts
        {
            get { return _baseViewModelHelper.GetMenuProductGroup(); }
        }

        public string FooterAddress { get { return _baseViewModelHelper.GetAddress(); } }
        public string FooterPhone { get { return _baseViewModelHelper.GetPhone(); } }
        public string FooterEmail { get { return _baseViewModelHelper.GetEmail(); } }
        public string FooterAbout { get { return _baseViewModelHelper.GetFooterAbout(); } }

        public List<Blog> FooterLatestBlog { get { return _baseViewModelHelper.GetFooterLatestBlogs(); } }
        public List<PageGroupsMenu> PageGroupsMenus { get { return _baseViewModelHelper.GetPageGroups(); } }
        public List<Page> PagesMenu { get { return _baseViewModelHelper.GetPages(); } }
        public List<TextTypeItem> SocialText { get { return _baseViewModelHelper.GetSocial(); } }
        public List<TextTypeItem> SupportLinks { get { return _baseViewModelHelper.GetSupportLinks(); } }
        public TextTypeItem WhatsappInfo { get { return _baseViewModelHelper.GetWhatsappInfo(); } }

    }
    public class PageGroupsMenu
    {
        public PageGroup PageGroup { get; set; }
        public List<Page> Pages { get; set; }
    }

}