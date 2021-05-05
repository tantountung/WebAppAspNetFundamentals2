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
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel vm)
        {
            vm = _peopleService.FindBy(vm);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePerson());
        }

        [HttpPost]
        public IActionResult Create(CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }

            return View(createPerson);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _peopleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

       
        //[HttpPost]
        //public IActionResult Delete(int id, DeletePerson deletePerson)
        //{
        //    Person person = _peopleService.FindBy(id);

        //    if (person == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    DeletePerson deletePerson = new DeletePerson();
        //    deletePerson.Delete = _peopleService.Remove(id);

        //    return View(deletePerson);
        //}
    }
}
//public bool Remove(int id)
//{
//    Person originalPerson = FindBy(id);

//    if (originalPerson == null)
//    {
//        return false;
//    }
//    return _peopleRepo.Delete(originalPerson);
