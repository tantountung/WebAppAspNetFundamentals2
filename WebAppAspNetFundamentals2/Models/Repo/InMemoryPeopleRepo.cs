using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models
{

    //    InMemoryPeopleRepo – Implements IPeopleRepo interface and these two fields.
    //▪ Private static List of Person.
    //▪ Private static int idCounter.

    public class InMemoryPeopleRepo : IPeopleRepo
    {
        int idCounter = 0;
        List<Person> peopleList = new List<Person>();

        public Person Create(CreatePersonViewModel createperson)
        {
            Person person = new Person();

            person.Id = ++idCounter;
            person.Name = createperson.Name;
            person.PhoneNumber = createperson.PhoneNumber;
            person.CityName = createperson.CityName;
            person.CountryName = createperson.CountryName;

            peopleList.Add(person);

            return person;
        }


        public Person Read(int id)
        {
            foreach (Person item in peopleList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Person> Read()
        {
            return peopleList;
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
           
            originalPerson.CityName = person.CityName;
            originalPerson.CountryName = person.CountryName;

            return originalPerson;
        }

        public bool Delete(Person person)
        {
            Person genuinePerson = Read(person.Id);

            if (genuinePerson == null)
            {
                return false;
            }

            return peopleList.Remove(genuinePerson);
        }



    }
}
