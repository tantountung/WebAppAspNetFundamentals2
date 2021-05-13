using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class CreateLanguage
    {
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public string LanguangeName { get; set; }

        public CreateLanguage()
        {
            //zero constructor to be exist
        }
    }
} 