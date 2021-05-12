using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public List<City> Citygroup { get; set; }
    }
}
