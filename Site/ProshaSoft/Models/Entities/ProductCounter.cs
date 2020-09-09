using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Models
{
    public class ProductCounter:BaseEntity
    {
        [Display(Name = "ویژگی")]
        public string Key { get; set; }

        [Display(Name = "ویژگی انگلیسی")]
        public string KeyEN { get; set; }

        [Display(Name = "مقدار")]
        public string Value { get; set; }

        [Display(Name = "مقدار انگلیسی")]
        public string ValueEN { get; set; }

        [Display(Name = "محصول")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        internal class Configuration : EntityTypeConfiguration<ProductCounter>
        {
            public Configuration()
            {
                HasRequired(p => p.Product)
                    .WithMany(j => j.ProductCounters)
                    .HasForeignKey(p => p.ProductId);
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
                        return this.KeyEN;
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
                        return this.ValueEN;
                    case "fa-ir":
                        return this.Value;
                    default:
                        return String.Empty;
                }
            }
        }

    }
}