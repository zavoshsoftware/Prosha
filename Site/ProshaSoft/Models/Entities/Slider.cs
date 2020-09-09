using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Models
{
    public class Slider:BaseEntity
    {
       
        [Display(Name ="عنوان")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }


        [Display(Name = "خلاصه")]
        [MaxLength(600, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        [Display(Name = "خلاصه انگلیسی")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string SummaryEn { get; set; }



        [Display(Name = "متن لینک")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string LinkTitle { get; set; }


        [Display(Name = "متن لینک انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string LinkTitleEn { get; set; }

        [Display(Name = "آدرس لینک")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string LinkAddress { get; set; }

        [Display(Name = "متن لینک 2")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string LinkTitle2 { get; set; }

        [Display(Name = "متن لینک 2انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string LinkTitle2En { get; set; }


        [Display(Name = "آدرس لینک 2")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string LinkAddress2 { get; set; }

        [Display(Name = "لینک ویدیو است؟")]
        public bool IsVideoLink { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string ImageUrl { get; set; }
        [Display(Name = "اولویت نمایش")]
        public int Order { get; set; }

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
        public string SummarySrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.SummaryEn;
                    case "fa-ir":
                        return this.Summary;
                    default:
                        return String.Empty;
                }
            }
        }

        [NotMapped]
        public string LinkTitleSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.LinkTitleEn;
                    case "fa-ir":
                        return this.LinkTitle;
                    default:
                        return String.Empty;
                }
            }
        }

        [NotMapped]
        public string LinkTitle2Srt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.LinkTitle2En;
                    case "fa-ir":
                        return this.LinkTitle2;
                    default:
                        return String.Empty;
                }
            }
        }

    }
}