using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EEAffiliate.DAL;

namespace EEAffiliate.Controllers
{
    public class ActivateController : Controller
    {
        MailDal objMail = new MailDal();
        public ActionResult Verification(string user, string code)
        {
            try
            {
                objMail.WelcomeSendMail(user);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public ActionResult ResetPassword(string user, string code)
        {
            try
            {
                Session["User"] = user;
                return RedirectToAction("ResetPassword", "PasswordReset");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}