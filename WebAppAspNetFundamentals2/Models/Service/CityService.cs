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
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        public CityService(IPeopleRepo peopleRepo, ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }

        public City Add(CreateCity createCity)
        {
            City city = new City();

            city.CityName = createCity.CityName;
            city.Country = _countryRepo.Read(createCity.CountryId);

            return _cityRepo.Create(city);
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public List<City> JsonAll()
        {
            List<City> newList = _cityRepo.Read();//if in controller, must be _cityService

            foreach (var city in newList)
            {
                //city.Country = null;
                city.Population = null;

                if (city.Country != null)
                {
                    city.Country.Citygroup = null;
                }
                //city.Country.Citygroup = null;//dimished the infinite loop,
                ////beofer the error message is 'maximum depth is 32'

                //if (city.Population != null)
                //{
                //    city.Population. = null;
                //}
            }

            return newList;
        }

        public City FindById(int id)
        {
            return _cityRepo.Read(id);
        }

        public City Edit(int id, CreateCity city)
        {
            City originalCity = FindById(id);

            if (originalCity == null)
            {
                return null;
            }
            originalCity.CityName = city.CityName;
            originalCity = _cityRepo.Update(originalCity);

            return originalCity;
        }

        public bool Remove(int id)
        {
            return _cityRepo.Delete(id);
        }
    }
}
