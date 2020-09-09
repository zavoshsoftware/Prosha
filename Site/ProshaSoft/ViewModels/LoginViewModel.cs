using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModels
{
    public class LoginViewModel:_BaseViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remmember Me")]
        public bool RememberMe { get; set; }
    }
}