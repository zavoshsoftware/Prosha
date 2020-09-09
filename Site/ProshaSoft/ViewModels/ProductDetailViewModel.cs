using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class ProductDetailViewModel:_BaseViewModel
    {
        public Product Product { get; set; }
        public List<Blog> SidebarLatestBlog { get; set; }
        public List<Product> SidebarProducts { get; set; }
        public List<ProductComment> ProductComments { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductCounter> ProductCounters { get; set; }

    }
}