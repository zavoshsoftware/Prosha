using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class Product:BaseEntity
    {
        public Product()
        {
            ProductComments=new List<ProductComment>();
            ProductFeatures=new List<ProductFeature>();
            ProductCounters = new List<ProductCounter>();
        }

        [Display(Name = "Order", ResourceType = typeof(Resources.Models.Product))]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public int Order { get; set; }

        [Display(Name = "پارامتر url")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string UrlParam { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Resources.Models.Product))]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public int Code { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Models.Product))]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [StringLength(256, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }

        [Display(Name = "PageTitle", ResourceType = typeof(Resources.Models.Product))]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string PageTitle { get; set; }

        [Display(Name = "عنوان صفحه انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string PageTitleEn { get; set; }

        [Display(Name = "PageDescription", ResourceType = typeof(Resources.Models.Product))]
        [StringLength(1000, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        [DataType(DataType.MultilineText)]
        public string PageDescription { get; set; }

        [Display(Name = "توضیحات صفحه انگلیسی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string PageDescriptionEn { get; set; }

        [Display(Name = "تصویر صفحه داخلی")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string ImageUrl { get; set; }

        [Display(Name = "تصویر thumbnail")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string ThumbImageUrl { get; set; }

        [Display(Name = "تصویر header صفحه داخلی")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string HeaderImageUrl { get; set; }

        [Display(Name = "Summery", ResourceType = typeof(Resources.Models.Product))]
        [DataType(DataType.MultilineText)]
        public string Summery { get; set; }

        [Display(Name = "خلاصه انگلیسی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string SummeryEn { get; set; }

        [Display(Name = "Body", ResourceType = typeof(Resources.Models.Product))]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        public string Body { get; set; }

        [Display(Name = "توضیحات انگلیسی")]
        [UIHint("RichText")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string BodyEn { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        public virtual ICollection<ProductCounter> ProductCounters { get; set; }


        Helpers.GetCulture oGetCulture = new Helpers.GetCulture();

        [NotMapped]
        public string TitleSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.TitleEn;
                    case "fa-ir":
                        return this.Title;
                    default:
                        return String.Empty;
                }
            }
        }


        [NotMapped]
        public string SummerySrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.SummeryEn;
                    case "fa-ir":
                        return this.Summery;
                    default:
                        return String.Empty;
                }
            }
        }

        [NotMapped]
        public string BodySrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.BodyEn;
                    case "fa-ir":
                        return this.Body;
                    default:
                        return String.Empty;
                }
            }
        }

        [NotMapped]
        public string PageTitleSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.PageTitleEn;
                    case "fa-ir":
                        return this.PageTitle;
                    default:
                        return String.Empty;
                }
            }
        }
        [NotMapped]
        public string PageDescriptionSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.PageDescriptionEn;
                    case "fa-ir":
                        return this.PageDescription;
                    default:
                        return String.Empty;
                }
            }
        }
    }
}