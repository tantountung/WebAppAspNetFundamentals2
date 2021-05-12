using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class PeopleViewModel
    {
        

        private string search;

        public string Search
        {
            get { return search; }
            set
            {
                if (value == null)
                {
                    return;
                }

                search = value.ToLower();
            }



        }

        public CreatePerson createPerson { get; set; }


        public List<Person> PeopleList { get; set; }

        public PeopleViewModel()
        {
            PeopleList = new List<Person>();
            createPerson = new CreatePerson();
        }
    }
}
