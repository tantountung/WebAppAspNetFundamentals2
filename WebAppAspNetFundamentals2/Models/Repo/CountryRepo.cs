using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public class CountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public CountryRepo(PeopleDbContext peopleDbContext)
        {
            this._peopleDbContext = peopleDbContext;
        }

        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return country;

        }


        public Country Read(int id)
        {
            return _peopleDbContext.Countries.Find(id);
        }

        public List<Country> Read()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country Update(Country country)
        {
            Country originalCity = Read(country.Id);

            if (originalCity == null)
            {
                return null;
            }

            //originalCity.CityName = city.CityName;
            _peopleDbContext.Update(country);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return country;

        }
        public bool Delete(int id)
        {
            Country originalCity = Read(id);

            if (originalCity == null)
            {
                return false;
            }

            _peopleDbContext.Countries.Remove(originalCity);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
