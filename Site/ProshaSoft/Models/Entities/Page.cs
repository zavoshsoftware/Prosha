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
    public class Page:BaseEntity
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [StringLength(256, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }

        [Display(Name = "پارامتر url")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string UrlParam { get; set; }

        [Display(Name = "در صفحه اصلی باشد؟")]
        public bool IsInHome { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public int Order { get; set; }

        [Display(Name = "گروه")]
        public Guid? PageGroupId { get; set; }
        public PageGroup PageGroup { get; set; }

        [Display(Name = "تصویر صفحه داخلی")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string ImageUrl { get; set; }

        [Display(Name = "تصویر header صفحه داخلی")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string HeaderImageUrl { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        public string Body { get; set; }
        [Display(Name = "توضیحات")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        public string BodyEn { get; set; }

        internal class Configuration : EntityTypeConfiguration<Page>
        {
            public Configuration()
            {
                HasRequired(p => p.PageGroup)
                    .WithMany(j => j.Pages)
                    .HasForeignKey(p => p.PageGroupId);
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
    }
}