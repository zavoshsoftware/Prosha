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
    public class Blog : BaseEntity
    {
        public Blog()
        {
            BlogComments=new List<BlogComment>();
        }
        [Display(Name = "عنوان نوشته")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }

        [Display(Name = "خلاصه نوشته")]
        [DataType(DataType.MultilineText)]
        public string Summery { get; set; }

        [Display(Name = "خلاصه انگلیسی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string SummeryEn { get; set; }


        [Display(Name = "تصویر نوشته")]
        public string ImageUrl { get; set; }

        [Display(Name = "تصویر نوشته")]
        public string ImageUrlThumb { get; set; }

        [Display(Name = "تصویر header صفحه داخلی")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string HeaderImageUrl { get; set; }

        [Display(Name = "پارامتر url")]
        public string UrlParam { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "متن")]
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

        public virtual ICollection<BlogComment> BlogComments { get; set; }

        [Display(Name = "عنوان صفحه")]
        public string PageTitle { get; set; }

        [Display(Name = "عنوان صفحه انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string PageTitleEn { get; set; }

        [Display(Name = "توضیحات صفحه")]
        public string PageDescription { get; set; }


        [Display(Name = "توضیحات صفحه انگلیسی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string PageDescriptionEn { get; set; }

        [Display(Name = "مقاله پیشنهادی؟")]
        public bool IsRelated { get; set; }

        [Display(Name = "گروه ")]
        public Guid? BlogGroupId { get; set; }
        public BlogGroup BlogGroup { get; set; }

        internal class configuration : EntityTypeConfiguration<Blog>
        {
            public configuration()
            {
                HasRequired(p => p.BlogGroup).WithMany(t => t.Blogs).HasForeignKey(p => p.BlogGroupId);
            }
        }

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