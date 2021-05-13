using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Service;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }


        // GET: LanguagesController
        public ActionResult Index()
        {
            return View(_languageService.All());
        }

        // GET: LanguagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LanguagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguage createLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Add(createLanguage);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createLanguage);
            }
        }

        // GET: LanguagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LanguagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LanguagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
