using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.Entities;
using StoreAppNG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppNG.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<AppUser> userMgr { get; }
        private SignInManager<AppUser> signInMgr { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            userMgr = userManager;
            signInMgr = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser userExist = await userMgr.FindByNameAsync(register.UserName);
                    if (userExist != null)
                    {
                        ViewBag.Message = "User already exists!";
                    }
                    else
                    {
                        var user = new AppUser
                        {
                            UserName = register.UserName,
                            FirstName = register.FirstName,
                            LastName = register.LastName,
                            Email=register.UserName+"@test.com"
                        };
                        IdentityResult result = await userMgr.CreateAsync(user, register.Password);
                        result = await userMgr.AddToRoleAsync(user, "Admin");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInMgr.PasswordSignInAsync(login.UserName, login.Password, true, false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction("Index", "Product");
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInMgr.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }


    }
}
