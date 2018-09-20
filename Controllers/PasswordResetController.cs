using EEAffiliate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAffiliate.Controllers
{
    public class PasswordResetController : Controller
    {

        PasswordDal objPassword = new PasswordDal();
        AffiliateRegister registermodel = new AffiliateRegister();
        // GET: PasswordReset

        public ActionResult ForgotPassword()
        {
            return View();
        }



        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            try
            {
                registermodel.EmailId = Email;
                string response = objPassword.CheckUser(Email);
                if (response == "success")
                {
                    ViewBag.ForgotPasswordstatus = response;
                    return View();
                }
                else
                {
                    ViewBag.ForgotPasswordError = response;
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public ActionResult ResetPassword(string ActivationCode)
        {
            try {

                ViewBag.ActivationCode = ActivationCode;
                // ViewBag.ActivationCode = 123456;
                return View();
            }
            catch(Exception ex)
            {
                throw;
            }
            }



        [HttpPost]
        public ActionResult ResetPassword(string Password,string code)
        {
            try
            {
                string Result = objPassword.ConfirmPassword(Password, code.ToString());
                ViewBag.Message = Result;
                return View();

                //return Json(Result);

            }
            catch (Exception ex)
            {

                throw;
            }
           
         }
    }
}