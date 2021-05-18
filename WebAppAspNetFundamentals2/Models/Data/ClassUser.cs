using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.Data
{
    public class ClassUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }
    }
}
