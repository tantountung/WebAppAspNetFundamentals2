using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models
{

    //    IPeopleRepo – Interface with following methods.
    //▪ Person Create(“parameters needed to create Person excluding id”)
    //▪ List<Person> Read()
    //▪ Person Read(int id)
    //▪ Person Update(Person person)
    //▪ bool Delete(Person person)

    public interface IPeopleRepo
    {
        Person Create(Person person);

        Person Read(int id);
        List<Person> Read();
        Person Update(Person person);

        bool Delete(Person person);



        
    }
}
