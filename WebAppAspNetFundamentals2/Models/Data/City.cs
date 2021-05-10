using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [MaxLength (100)]
        public string CityName { get; set; }

        [Required]
        public Person PersonInQuestion { get; set; }






    }
}
