using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public interface ILanguageRepo
    {
        Language Create(Language language);

        Language Read(int id);
        List<Language> Read();
        Language Update(Language language);

        bool Delete(int id);
    }
}
