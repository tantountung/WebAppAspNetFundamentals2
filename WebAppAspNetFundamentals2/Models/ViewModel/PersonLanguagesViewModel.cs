using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class PersonLanguagesViewModel
    {
        public Person Person { get; set; }

        public List<Language> Languages { get; set; }
    }
}
