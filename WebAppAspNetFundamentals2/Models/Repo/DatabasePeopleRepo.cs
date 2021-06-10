using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;
        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            this._peopleDbContext = peopleDbContext;
        }

        public Person Create(CreatePersonViewModel createperson)
        {
            Person person = new Person();

            person.Name = createperson.Name;
            person.PhoneNumber = createperson.PhoneNumber;
            person.CityId = createperson.CityId;
            //person.CountryName = createperson.CountryName;

            _peopleDbContext.People.Add(person);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("unable to add person in database.");
            }

            return person;
        }


        public Person Read(int id)
        {
            Person newPerson = _peopleDbContext.People.Find(id);

            if (newPerson != null)
            {
                newPerson = _peopleDbContext.People
                                .Include(person => person.PersonLanguages)
                                .ThenInclude(perLan => perLan.Language)
                                .Include(person => person.City)
                                .ThenInclude(city => city.Country)
                                .SingleOrDefault(row => row.Id == id);

                if (newPerson.PersonLanguages != null)
                    foreach (var item in newPerson.PersonLanguages)
                    {
                        item.Person = null;
                        item.Language.PersonLanguages = null;
                    }

                if (newPerson.City.Country != null)
                {
                    newPerson.City.Country.Citygroup = null;
                }
                newPerson.City.Population = null;
            }
            return newPerson;


        }

        public List<Person> Read()
        {
            return _peopleDbContext.People.Include("City").
                ToList();
        }

        public List<Person> JsonRead()
        {
            List<Person> newList = _peopleDbContext.People
                .Include("City")
                .ToList();

            foreach (var person in newList)
            {
                person.City.Population = null;

                if (person.City.Country != null)
                {
                    person.City.Country.Citygroup = null;
                }
            }

            return newList;
        }




        public Person Update(Person person)
        {
            Person originalPerson = Read(person.Id);

            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.Name = person.Name;
            originalPerson.PhoneNumber = person.PhoneNumber;
            originalPerson.CityId = person.CityId;
            //originalPerson.CountryName = person.CountryName;

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("unable to update person in database.");
            }

            return originalPerson;
        }
        public bool Delete(Person person)
        {
            Person genuinePerson = Read(person.Id);

            if (genuinePerson == null)
            {
                return false;
            }

            _peopleDbContext.People.Remove(genuinePerson);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("unable to delete person in database.");
            }

            return true;
        }
    }
}
