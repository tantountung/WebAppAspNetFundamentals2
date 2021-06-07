using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Repo;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        ICityRepo _cityRepo;
        ICountryRepo _countryRepo;

        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }

        public Person Add(CreatePersonViewModel createPerson)
        {
            Person person1 = _peopleRepo.Create(createPerson);

            return person1;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel vm = new PeopleViewModel();// there is loop for population and citygroup
            //but C# and razor can manage it but not Json converter, thats why
            // stuck in /api/react


            vm.PeopleList = _peopleRepo.Read();
            vm.createPerson.CityList = _cityRepo.Read();

            return vm;
        }

        public List<Person> JsonAll()//vreated to avoid infinite loop,
                                     //bware of the next loop for language and person
        {
            List<Person> newList = _peopleRepo.Read();//if in controller, must be _peopleService

            foreach (var person in newList)
            {
                person.CityName.Population = null;//dimished the infinite loop,
                //beofer the error message is 'maximum depth is 32'

                if (person.CityName.Country != null)
                {
                    person.CityName.Country.Citygroup = null;
                }



            }

            return newList;

        }

        public PeopleViewModel FindBy(PeopleViewModel vm)
        {
            if (vm.Search == null)
            {
                return vm;
            }

            foreach (Person item in _peopleRepo.Read())
            {
                if (item.Name.ToLower().Contains(vm.Search))
                {
                    vm.PeopleList.Add(item);
                }
            }
            return vm;
        }
        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public Person EditPerson(int id, CreatePersonViewModel createPerson)
        {
            Person originalPerson = FindBy(id);

            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.Name = createPerson.Name;
            originalPerson.PhoneNumber = createPerson.PhoneNumber;
            originalPerson.CityName = createPerson.CityName;
            originalPerson.CountryName = createPerson.CountryName;

            originalPerson = _peopleRepo.Update(originalPerson);

            return originalPerson;
        }


        public bool Remove(int id)
        {
            Person originalPerson = FindBy(id);

            if (originalPerson == null)
            {
                return false;
            }
            return _peopleRepo.Delete(originalPerson);
        }

        public CreatePersonViewModel PersonToCreatePerson(Person person)
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();

            createPerson.Name = person.Name;
            createPerson.PhoneNumber = person.PhoneNumber;
            createPerson.CityName = person.CityName;
            createPerson.CountryName = person.CountryName;


            return createPerson;
        }

    }
}
