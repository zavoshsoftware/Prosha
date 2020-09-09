using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class AboutViewModel : _BaseViewModel
    {
        public TextTypeItem Aboutus { get; set; }
        public List<TextTypeItem> HistoryTexts { get; set; }
       
        public TextTypeItem StartWithProsha { get; set; }
        public List<TextTypeItem> MiddleBanner { get; set; }
        public List<TextTypeItem> Missions { get; set; }






    }
}