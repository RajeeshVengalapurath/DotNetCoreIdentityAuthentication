using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreIdentityAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }        
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                // or await _signInManager.PasswordSignInAsync(username, password, false, false);
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if(signInResult.Succeeded)
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Register(string username, string password)
        {   
            return RedirectToAction("Index");
        }
    }
}
