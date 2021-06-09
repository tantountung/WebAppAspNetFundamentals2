using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Service;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IPeopleRepo _peopleRepo;

        public CitiesController(ICityService cityService, ICountryService countryService, IPeopleRepo peopleRepo)
        {
            this._cityService = cityService;
            _countryService = countryService;
            _peopleRepo = peopleRepo;
        }

        // GET: CitiesController
        public ActionResult Index()
        {
            return View(_cityService.JsonAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateCity newcity = new CreateCity();
            newcity.CountryList = _countryService.All();

            return View(newcity);
        }

        [HttpPost]
        public IActionResult Create(CreateCity createCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(createCity);

                return RedirectToAction(nameof(Index));
            }

            return View(createCity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            City person = _cityService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _cityService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
      
    }
}
