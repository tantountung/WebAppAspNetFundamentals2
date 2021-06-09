using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        

        public int CityId { get; set; }

        //public Country CountryId { get; set; }

        public List<City> CityList { get; set; }

        //public List<Country> CountryList { get; set; }

        public CreatePersonViewModel()
        {
            CityList = new List<City>();
            CityId = new int();
            //CountryList = new List<Country>();
            //CountryId = new int();
        }


    }
}
