using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.ViewModel
{
    public class EditPerson
    {
        public int Id { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
    }
}
