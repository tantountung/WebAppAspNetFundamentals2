using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Service;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageService _personLanguageService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public ReactController(IPeopleService peopleService, ILanguageService languageService, IPersonLanguageService personLanguageService,  ICityService cityService, ICountryService countryService)
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
            _cityService = cityService;
            _countryService = countryService;
        }


        [HttpGet]
        public List<Person> Get()
        {
            return _peopleService.JsonAll();//created so no function in controller but only in service
        }

        [HttpGet("{id}")]
        public Person GetById(int id)
        {
            return _peopleService.JsonFindBy(id);//created so no function in controller but only in service
        }


        [HttpPost]
        public ActionResult<Person> Create([FromBody] CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                return _peopleService.Add(person);
            }
            return BadRequest(person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                Response.StatusCode = 200;
            }
            Response.StatusCode = 400;
        }
        //------------------------City------------

        [HttpGet("Cities")]
        public List<City> GetCities()
        {
            return _cityService.JsonAll();
        }


        [HttpGet("Countries")]
        public List<Country> GetCountries()
        {
            return _countryService.All();
        }

    }
}
