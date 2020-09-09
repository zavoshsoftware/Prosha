using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Models
{
    public class ProductFeature : BaseEntity
    {
        [Display(Name="ویژگی")]
        public string Key { get; set; }

        [Display(Name = "ویژگی انگلیسی")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر {0} نباید بیشتر از {1} باشد.")]
        public string KeyEn { get; set; }

        [Display(Name="مقدار")]
        [DataType(DataType.MultilineText)]
        public string Value { get; set; }

        [Display(Name = "مقدار انگلیسی")]
        public string ValueEn { get; set; }

        [Display(Name="محصول")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Code { get; set; }

        internal class configuration : EntityTypeConfiguration<ProductFeature>
        {
            public configuration()
            {
                HasRequired(p => p.Product).WithMany(t => t.ProductFeatures).HasForeignKey(p => p.ProductId);
            }
        }

        Helpers.GetCulture oGetCulture = new Helpers.GetCulture();

        [NotMapped]
        public string KeySrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.KeyEn;
                    case "fa-ir":
                        return this.Key;
                    default:
                        return String.Empty;
                }
            }
        }

        [NotMapped]
        public string ValueSrt
        {
            get
            {
                string currentCulture = oGetCulture.CurrentLang();
                switch (currentCulture.ToLower())
                {
                    case "en-us":
                        return this.ValueEn;
                    case "fa-ir":
                        return this.Value;
                    default:
                        return String.Empty;
                }
            }
        }
    }
}