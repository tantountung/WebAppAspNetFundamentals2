using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetFundamentals2.Models.Data;

namespace WebAppAspNetFundamentals2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ClassUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ClassUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> Details(string id)
        {
            ClassUser userFound = await _userManager.FindByIdAsync(id);

            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }
            return View(userFound);
        }

        public async Task<IActionResult> RolesManagement(string id)
        {
            ClassUser userFound = await _userManager.FindByIdAsync(id);



            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }
            return View(userFound);
        }


    }
}
