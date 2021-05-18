using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class UserRegViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(60, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(60, MinimumLength = 5)]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Required]
        [Display(Name ="Password")]
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
