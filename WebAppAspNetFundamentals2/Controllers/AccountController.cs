using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<ClassUser> _signInManager;

        public AccountController(UserManager<ClassUser> userManager, SignInManager<ClassUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult AccessDenied()
        {
            return View();
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
                   
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }

            }

            return View(userReg);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {

                Microsoft.AspNetCore.Identity.SignInResult result = 
                    await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);

                if (result.Succeeded)
                {
                    //To do - SIgnIn User
                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Locked out", "Too many login attempts");
                }

            }

            return View(userLogin);
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
