using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TextType:BaseEntity
    {
        public TextType()
        {
            TextTypeItems=new List<TextTypeItem>();
        }
        [Display(Name ="عنوان")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string TitleEn { get; set; }

        public ICollection<TextTypeItem> TextTypeItems { get; set; }

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