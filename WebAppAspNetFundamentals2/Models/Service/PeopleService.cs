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

        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
        }

        public Person Add(CreatePerson person)
        {
            Person person1 = new Person();

            person1.Name = person.Name;
            person1.PhoneNumber = person.PhoneNumber;
            person1.CityId = person.CityId;

            person1 = _peopleRepo.Create(person1);

            return person1;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel vm = new PeopleViewModel();

            vm.PeopleList = _peopleRepo.Read();
            vm.createPerson.CityList = _cityRepo.Read();

            return vm;
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

        public Person Edit(int id, Person person)
        {
            Person originalPerson = FindBy(id);

            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.Name = person.Name;
            originalPerson.PhoneNumber = person.PhoneNumber;
            originalPerson.CityId = person.CityId;

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

    }
}
