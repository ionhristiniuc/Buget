using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Buget.WebUI.Interfaces.UserAccount;
using Buget.WebUI.ViewModels;

namespace Buget.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserAccountService _accountService;

        public AccountController(IUserAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult LogOn()
        {
            var viewModel = new LogOnViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userModel = _accountService.LogOn(model.Login.Trim(), model.Password.Trim());

                if (userModel != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    return RedirectToAction("Index", "Home");
                }                                
            }

            return View(model);                                       
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}