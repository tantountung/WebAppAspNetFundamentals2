using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext peopleDbContext;
        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            this.peopleDbContext = peopleDbContext;
        }

        public Person Create(Person person)
        {
            peopleDbContext.People.Add(person);

            int result = peopleDbContext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("unable to add person in database.");
            }

            return person;
        }


        public Person Read(int id)
        {
            return peopleDbContext.People.SingleOrDefault(row => row.Id == id);
        }

        public List<Person> Read()
        {
            return peopleDbContext.People.Include("City").ToList();
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

            int result = peopleDbContext.SaveChanges();

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

            peopleDbContext.People.Remove(genuinePerson);

            int result = peopleDbContext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("unable to delete person in database.");
            }

            return true;
        }
    }
}
