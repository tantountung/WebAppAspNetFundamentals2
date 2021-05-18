using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Repo;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public PersonLanguageService(IPersonLanguageRepo personLanguageRepo)
        {
            _personLanguageRepo = personLanguageRepo;
        }


        public PersonLanguage Create(PersonLanguage personLanguage)
        {

            return _personLanguageRepo.Create(personLanguage);
        }
        public List<PersonLanguage> All()
        {
            return _personLanguageRepo.Read();
        }
        public PersonLanguage FindBy(int personId, int languageId)
        {
            return _personLanguageRepo.Read(personId, languageId);
        }

        public bool Remove(int personId, int languageId)
        {
            return _personLanguageRepo.Delete(personId, languageId);
        }
    }
}
