using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public interface IPersonLanguageRepo
    {
        PersonLanguage Create(PersonLanguage personLanguage);

        PersonLanguage Read(int personId, int languageId);

        List<PersonLanguage> Read();

        bool Delete(int personId, int languageId);

    }
}
