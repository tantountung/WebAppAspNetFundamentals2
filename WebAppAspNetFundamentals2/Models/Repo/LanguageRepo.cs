using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Database;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Models.Repo
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public LanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Language Create(Language language)
        {
            _peopleDbContext.Add(language);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }

            return null;
        }

       
        public Language Read(int id)
        {
            return _peopleDbContext.Languages.SingleOrDefault(language => language.Id == id);
        }

        public List<Language> Read()
        {
            return _peopleDbContext.Languages.ToList();    
        }
 public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Language Update(Language language)
        {
            throw new NotImplementedException();
        }
    }
}
