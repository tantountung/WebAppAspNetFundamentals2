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
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: CitiesController
        public IActionResult Index()
        {
            return View(_countryService.All());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCountry createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(createCountry);

                return RedirectToAction(nameof(Index));
            }

            return View(createCountry);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Country person = _countryService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _countryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
