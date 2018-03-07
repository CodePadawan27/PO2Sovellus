using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PO2Sovellus.Entities;
using PO2Sovellus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Controllers
{
    public class TiliController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public TiliController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Rekisteroi()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Rekisteroi(RekisteroiUserViewModel malli)
        {
            if(ModelState.IsValid)
            {
                var user = new User { UserName = malli.UserName };
                var createResult = await _userManager.CreateAsync(user, malli.Password);
                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Etusivu");
                }
                else
                {
                    foreach (var virhe in createResult.Errors)
                    {
                        ModelState.AddModelError("", virhe.Description);
                    }
                }
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Ulos()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Etusivu");
        }

        [HttpGet]
        public IActionResult Sisaan()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Sisaan(SisaanViewModel malli)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(malli.UserName, malli.Password, malli.RememberMe, false);

                if(loginResult.Succeeded)
                {
                    if(Url.IsLocalUrl(malli.ReturnUrl))
                    {
                        return Redirect(malli.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Etusivu");
                    }
                }
            }
            ModelState.AddModelError("", "Sisäänkirjautuminen ei onnistunut");
            return View(malli);
        }
        
    }
}
