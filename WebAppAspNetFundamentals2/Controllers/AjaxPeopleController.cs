using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.ViewModel;
using WebAppAspNetFundamentals2.Models.Service;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Controllers
{
    public class AjaxPeopleController : Controller
    {
        IPeopleService _peopleService = new PeopleService();

        [HttpGet]
        public IActionResult AjaxIndex()
        {
            return View();
        }
    }
}

