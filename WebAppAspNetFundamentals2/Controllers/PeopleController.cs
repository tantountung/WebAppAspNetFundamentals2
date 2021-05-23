using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.ViewModel;
using WebAppAspNetFundamentals2.Models.Service;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.Repo;
using PersonLanguage = WebAppAspNetFundamentals2.Models.Data.PersonLanguage;
using Microsoft.AspNetCore.Authorization;

namespace WebAppAspNetFundamentals2.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        private readonly IPersonLanguageRepo _personLanguangeRepo;
        private readonly ILanguageService _languageService;

        public PeopleController(IPeopleService peopleService, IPersonLanguageRepo personLanguangeRepo,
            ILanguageService languageService)
        {
            _peopleService = peopleService;
            _personLanguangeRepo = personLanguangeRepo;
            _languageService = languageService;
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
            return View(new CreatePersonViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }

            return View(createPerson);
        }

        [HttpGet]
        public IActionResult ManagePersonLanguage(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            PersonLanguagesViewModel vm = new PersonLanguagesViewModel();
            vm.Person = person;
            vm.Languages = _languageService.All();


            return View(vm);
        }

        [HttpGet]
        public IActionResult AddLanguageToPerson(int personId, int languageId)
        {
            Person person = _peopleService.FindBy(personId);

            if (person == null)
            {
                return RedirectToAction("Index");
            }



            PersonLanguage personLanguage = _personLanguangeRepo.Create
                (new PersonLanguage() { PersonId = personId, LanguageId = languageId });



            return RedirectToAction("ManagePersonLanguage", new { id = personId });
        }

        [HttpGet]
        public IActionResult RemoveLanguageToPerson(int personId, int languageId)
        {
            Person person = _peopleService.FindBy(personId);

            if (person == null)
            {
                return RedirectToAction("Index");
            }



            _personLanguangeRepo.Delete(personId, languageId);



            return RedirectToAction("ManagePersonLanguage", new { id = personId });
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

        [HttpGet]
        public IActionResult EditPerson(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = _peopleService.PersonToCreatePerson(person);

            return View(editPerson);
        }

        [HttpPost]
        public IActionResult EditPerson(int id, CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                Person car = _peopleService.EditPerson(id, createPerson);

                return RedirectToAction(nameof(Index));
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = createPerson;

            return View(editPerson);



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
}
//public bool Remove(int id)
//{
//    Person originalPerson = FindBy(id);

//    if (originalPerson == null)
//    {
//        return false;
//    }
//    return _peopleRepo.Delete(originalPerson);
