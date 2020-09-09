using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class HomeViewModel : _BaseViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<TextTypeItem> Numbers { get; set; }
        public List<Team> TeamMembers { get; set; }
        public TextTypeItem About { get; set; }
        public TextTypeItem PosInfo { get; set; }
        public TextTypeItem FeaturImage { get; set; }
        public TextTypeItem MapDescription { get; set; }


        public List<TextTypeItem> FeaturesTexts { get; set; }

        public List<Product> Products { get; set; }

        public List<Blog> LatestBlogs { get; set; }
        public List<MapDetail> MapDetails { get; set; }
        public List<MiniSlider> MiniSliders { get; set; }
        public List<MiniSlider> DesktopSliders { get; set; }
        public List<Costumer> Costumers { get; set; }



    }
}