using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class CreatePerson
    {
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
         
        [Required]
        public string City { get; set; }

      

    }
}
