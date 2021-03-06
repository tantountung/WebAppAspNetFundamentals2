using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{

    //▪ Person Add(CreatePersonViewModel person)
    //▪ PeopleViewModel All()
    //▪ PeopleViewModel FindBy(PeopleViewModel search)
    //▪ Person FindBy(int id)
    //▪ Person Edit(int id, Person person)
    //▪ bool Remove(int id)

    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel createPerson);
        PeopleViewModel All();

        List<Person> JsonAll();
        PeopleViewModel FindBy(PeopleViewModel Search);
        Person FindBy(int id);//copy line with Ctrl D

        Person JsonFindBy(int id);
        Person EditPerson(int id, CreatePersonViewModel createPerson);
        CreatePersonViewModel PersonToCreatePerson(Person person);
        bool Remove(int id);
    }
}

