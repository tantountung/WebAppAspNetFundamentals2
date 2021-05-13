using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Repo;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }

        public Language Add(CreateLanguage createLanguage)
        {
            Language language = new Language()
            {
                LanguangeName = createLanguage.LanguangeName
            };

            return _languageRepo.Create(language);
        }

        public List<Language> All()
        {
            return _languageRepo.Read();
        }



        public Language FindById(int id)
        {
            return _languageRepo.Read(id);
        }

        public Language Edit(int id, CreateLanguage language)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
