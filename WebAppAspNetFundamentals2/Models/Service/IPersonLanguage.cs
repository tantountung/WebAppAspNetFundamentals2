using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Service
{
    public interface IPersonLanguage
    {
        PersonLanguage Create(PersonLanguage personLanguage);
        List<PersonLanguage> All();

        PersonLanguage FindBy(int personId, int languageId);
        
        bool Remove(int personId, int languageId);

    }
}
