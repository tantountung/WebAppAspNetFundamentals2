using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public interface ICityService
    {
        City Add(CreateCity createCity);
        List<City> All();

        List<City> FindByCityId(int CityId);

        City FindById(int id);
        City Edit(int id, CreateCity city);
        bool Remove(int id);
    }
}
