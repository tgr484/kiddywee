using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiddywee.BLL.Interfaces;
using Kiddywee.BLL.Repositories;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kiddywee.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IEmailSender emailSender, 
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if(_signInManager.IsSignedIn(User))
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (String.IsNullOrEmpty(returnUrl) && String.IsNullOrEmpty(returnUrl.Replace("/","")))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Invalid user or password");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.Create(model.FirstName, model.LastName);
                await _unitOfWork.People.Insert(person);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    var applicationUser = ApplicationUser.Create(person.Id, model.Email);
                    var user = await _userManager.CreateAsync(applicationUser, model.Password);
                    if (user.Succeeded)
                    {
                        await _unitOfWork.People.Insert(person);
                        await _unitOfWork.SaveAsync();
                        return RedirectToAction(nameof(Login));
                    }
                    AddErrors(user);
                }
                else
                {
                    AddErrors(result);
                }
            }
            return View(model);
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
