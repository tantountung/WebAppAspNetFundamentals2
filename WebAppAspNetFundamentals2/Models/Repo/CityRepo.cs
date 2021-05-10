using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public class CityRepo : ICityRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public CityRepo(PeopleDbContext peopleDbContext)
        {
            this._peopleDbContext = peopleDbContext;
        }

        public City Create(City city)
        {
            _peopleDbContext.Cities.Add(city);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return city;

        }


        public City Read(int id)
        {
            return _peopleDbContext.Cities.Find(id);
        }

        public List<City> Read()
        {
            return _peopleDbContext.Cities.ToList();
        }

        public City Update(City city)
        {
            City originalCity = Read(city.CityId);

            if (originalCity == null)
            {
                return null;
            }

            originalCity.CityName = city.CityName;

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalCity;

        }
        public bool Delete(int id)
        {
            City originalCity = Read(id);

            if (originalCity == null)
            {
                return false;
            }

            _peopleDbContext.Cities.Remove(originalCity);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
