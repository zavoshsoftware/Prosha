using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Team:BaseEntity
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Display(Name = "سمت")]
        public string Post { get; set; }
        [Display(Name = "خلاصه رزومه")]
        public string Summery { get; set; }
        [Display(Name = "تصویر")]
        public string ImageUrl { get; set; }
    }
}