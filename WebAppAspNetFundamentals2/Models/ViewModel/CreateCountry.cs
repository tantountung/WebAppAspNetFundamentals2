using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class CreateCountry
    {
        [Required]
        [MaxLength(100)]
        public string CountryName { get; set; }

        [Required]
        public City CityInQuestion { get; set; }

    }
}
