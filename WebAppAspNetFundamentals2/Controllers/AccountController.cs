using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;
using WebAppAspNetFundamentals2.Models.ViewModel;

namespace WebAppAspNetFundamentals2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ClassUser> _userManager;

        public AccountController(UserManager<ClassUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegViewModel userReg)
        {
            if (ModelState.IsValid)
            {
                ClassUser classUser = new ClassUser()
                {
                    UserName = userReg.UserName,
                    FirstName = userReg.FirstName,
                    LastName = userReg.LastName,
                    BirthDate = userReg.BirthDate,
                    Email = userReg.Email,
                    PhoneNumber = userReg.PhoneNumber
                };

                IdentityResult result = await _userManager.CreateAsync(classUser, userReg.Password);

                if (result.Succeeded)
                {
                    //To do - SIgnIn User
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }

            }

            return View(userReg);
        }
    }
}
