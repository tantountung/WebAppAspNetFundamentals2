using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public class PersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public PersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _peopleDbContext.PersonLanguages.Add(personLanguage);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return personLanguage;
            }

            return null;
        }

       

        public PersonLanguage Read(int personId, int languageId)
        {
            return _peopleDbContext.PersonLanguages
                .SingleOrDefault(pl => pl.PersonId == personId 
                && pl.LanguageId == languageId);
        }

        public List<PersonLanguage> Read()
        {
            return _peopleDbContext.PersonLanguages.ToList();
        }

        public bool Delete(int personId, int languageId)
        {
            PersonLanguage personLanguage = Read(personId, languageId);

            if (personLanguage == null)
            {
                return false;
            }

            _peopleDbContext.PersonLanguages.Remove(personLanguage);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
