using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Repo;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountry createCountry)
        {
            Country city = new Country();

            city.CountryName = createCountry.CountryName;


            return _countryRepo.Create(city);
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public List<Country> JsonAll()
        {
            List<Country> newList = _countryRepo.Read();//if in controller, must be _cityService

            foreach (var country in newList)
            {
                country.Citygroup = null;

                //if (country.Citygroup != null)
                //{
                //    country.Citygroup = null;
                //}
            }



            return newList;
        }
        public Country FindById(int id)
        {
            return _countryRepo.Read(id);
        }

        public Country Edit(int id, CreateCountry country)
        {
            Country originalCity = FindById(id);

            if (originalCity == null)
            {
                return null;
            }
            originalCity.CountryName = country.CountryName;
            originalCity = _countryRepo.Update(originalCity);

            return originalCity;
        }

        public bool Remove(int id)
        {
            return _countryRepo.Delete(id);
        }
    }
}
