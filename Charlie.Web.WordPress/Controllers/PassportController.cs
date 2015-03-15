using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ConfirmEmail()
        {
            return View();
        }
    }
}