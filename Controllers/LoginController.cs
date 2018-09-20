using EEAffiliate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAffiliate.Controllers
{
    public class LoginController : Controller
    {
        AffiliateRegister model = new AffiliateRegister();
        LoginDal objlogin = new LoginDal();
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string EmailId, string Password)
        {
            try
            {
                //LoginError
                model.EmailId = EmailId;
                model.Password = Password;

                //var UserName = objlogin.GetUserName(model);
                //var PhoneNo = objlogin.GetPhoneNo(model);

                //Session["UserName"] = UserName;
                //Session["PhoneNo"] = PhoneNo;


                string response = objlogin.Checklogin(model);
                if (response == "success")
                {
                    var LinkId = objlogin.GetLinkId(model);
                    Session["EmailId"] = EmailId;
                    Session["LinkId"] = LinkId;

                    return RedirectToAction("DashBoard", "DashBoard");
                }
                else if (response == "False")
                {
                    ViewBag.LoginError = "Invalid credentials, Please try again!";
                    return View();
                }

                else
                {
                    ViewBag.LoginError = "Username/Password cannot blank!";
                    return View();
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }


    }
}