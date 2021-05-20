using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(60, MinimumLength = 3)]
        public string UserName { get; set; }


        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 5)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
