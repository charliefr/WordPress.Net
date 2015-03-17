using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charlie.Web.WordPress.Models.Passport;

namespace Charlie.Web.WordPress.Controllers
{
    public partial class PassportController : Controller
    {
        // GET: Passport
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult ExternalLogin()
        {
            return View();
        }

        public ActionResult ExternalLoginCallback()
        {
            return View();
        }

        public ActionResult ExternalLoginConfirmation()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            return View();
        }

        public ActionResult SendCode()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost,AllowAnonymous,ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection formValues)
        {
            var model = new RegisterViewModel();
            if ( TryUpdateModel(model, formValues.GetPrefix()) && ModelState.IsValid )
            {
                var controller = new Api.Passport.RegisterController();
                controller.ExecutePost(model, this.HttpContext.GetOwinContext());

            }
            return View();
        }

        public ActionResult ConfirmEmail()
        {
            return View();
        }
    }
}