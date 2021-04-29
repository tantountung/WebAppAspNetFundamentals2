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
        Person Add(CreatePerson person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel Search);
        Person FindBy(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);
    }
}

