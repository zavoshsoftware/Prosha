using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ViewModels
{
    public class ContactViewModel:_BaseViewModel
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WorkTime { get; set; }
    }
}