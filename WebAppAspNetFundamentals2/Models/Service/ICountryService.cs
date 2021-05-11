using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public interface ICountryService
    {
        Country Add(CreateCountry createCountry);
        List<Country> All();

        Country FindById(int id);
        Country Edit(int id, CreateCountry country);
        bool Remove(int id);
    }
}
