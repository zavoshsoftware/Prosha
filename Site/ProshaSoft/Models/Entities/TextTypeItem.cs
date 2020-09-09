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
    public class TextTypeItem:BaseEntity
    {
        [Display(Name = "عنوان")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }

        [Display(Name = "خلاصه")]
        [DataType(DataType.MultilineText)]
        public string Summery { get; set; }

        [Display(Name = "خلاصه انگلیسی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string SummeryEn { get; set; }

        [Display(Name = "متن توضیحات")]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Body { get; set; }

        [Display(Name = "متن توضیحات انگلیسی")]
        [UIHint("RichText")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string BodyEn { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]

        public string ImageUrl { get; set; }
        [Display(Name = "گروه ")]
        public Guid TextTypeId { get; set; }

        public TextType TextType { get; set; }


        [MaxLength(100, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string Name { get; set; }
        internal class configuration : EntityTypeConfiguration<TextTypeItem>
        {
            public configuration()
            {
                HasRequired(p => p.TextType).WithMany(t => t.TextTypeItems).HasForeignKey(p => p.TextTypeId);
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

    }
}