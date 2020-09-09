using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class MapDetail :BaseEntity
    {
        [Display(Name="نام استان")]
        public string Title { get; set; }

        [Display(Name = "نام استان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        [Display(Name="خط اول توضیحات")]
        public string FirstLine { get; set; }

        [Display(Name = "خط اول توضیحات انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string FirstLineEn { get; set; }

        [Display(Name="خط دوم توضیحات")]
        public string SecondtLine { get; set; }

        [Display(Name = "خط دوم توضیحات انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string SecondtLineEn { get; set; }

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
        public string FirstLineSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.FirstLineEn;
                    case "fa-ir":
                        return this.FirstLine;
                    default:
                        return String.Empty;
                }
            }
        }

        [NotMapped]
        public string SecondtLineSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.SecondtLineEn;
                    case "fa-ir":
                        return this.SecondtLine;
                    default:
                        return String.Empty;
                }
            }
        }
    }
}