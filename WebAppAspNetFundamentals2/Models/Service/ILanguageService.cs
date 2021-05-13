using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public interface ILanguageService
    {
        Language Add(CreateLanguage createLanguage);
        List<Language> All();

        Language FindById(int id);
        Language Edit(int id, CreateLanguage language);
        bool Remove(int id);
    }
}
