using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels
{
    public class BlogDetailViewModel : _BaseViewModel
    {
        public Blog Blog { get; set; }
        public List<Blog> SidebarLatestBlog { get; set; }
        public List<Blog> RelateBlogs { get; set; }
        public List<Product> SidebarProducts { get; set; }
        public List<BlogComment> Comments { get; set; }
        public int CommentCount { get; set; }
    }
}