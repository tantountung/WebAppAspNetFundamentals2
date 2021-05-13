using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.Data
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string LanguangeName { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set; }

    }
}
