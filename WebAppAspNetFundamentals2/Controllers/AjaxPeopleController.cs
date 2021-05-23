using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.ViewModel;
using WebAppAspNetFundamentals2.Models.Service;
using WebAppAspNetFundamentals2.Models.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebAppAspNetFundamentals2.Controllers
{
    [Authorize]
    public class AjaxPeopleController : Controller
    {
        IPeopleService _peopleService;

        public AjaxPeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult AjaxIndex()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AjaxShowAll()
        {
            return PartialView("_PeoplePatialView", _peopleService.All().PeopleList);
        }

        [HttpPost]
        public IActionResult DetailPerson(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_PersonPatialView", person);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return NotFound();//404
            }

            if (_peopleService.Remove(id))
            {
                return Ok("person" + id);//200
            }

            return BadRequest();
        }

    }
}

