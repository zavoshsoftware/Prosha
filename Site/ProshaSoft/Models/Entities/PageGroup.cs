using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class PageGroup:BaseEntity
    {
        public PageGroup()
        {
            Pages = new List<Page>();
        }
        [Display(Name = "عنوان گروه")]
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
        public virtual ICollection<Page> Pages { get; set; }

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
    }
}