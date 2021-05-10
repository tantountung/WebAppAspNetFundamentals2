﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class CreateCity
    {
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        public Person PersonInQuestion { get; set; }

        public List<Person> PeopleList { get; set; }

    }
}
