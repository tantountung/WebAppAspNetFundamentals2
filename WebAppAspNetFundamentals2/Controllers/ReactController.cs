using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Service;

namespace WebAppAspNetFundamentals2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public ReactController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public List<Person> Get()
        {
            return _peopleService.All().PeopleList;
        }

    }
}
