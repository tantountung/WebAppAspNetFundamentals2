using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Repo;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Add(CreateCity createCity)
        {
            City city = new City();

            city.CityName = createCity.CityName;

            return _cityRepo.Create(city);
        }

        public List<City> All()
        {
            throw new NotImplementedException();
        }

        public City Edit(int id, CreateCity city)
        {
            throw new NotImplementedException();
        }

        public List<City> FindByCityId(int CityId)
        {
            throw new NotImplementedException();
        }

        public City FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
