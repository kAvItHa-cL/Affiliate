using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EEAffiliate.DAL;

namespace EEAffiliate.Controllers
{
    public class SettingsController : Controller
    {
        AffiliateRegister model = new AffiliateRegister();
        AffiliateUserDetail usermodel = new AffiliateUserDetail();
        SettingsDal objsettings = new SettingsDal();
        AffiliateRegister registermodel = new AffiliateRegister();

        // GET: Settings
        public ActionResult Settings()
        {
            try
            {
                if (Session["EmailId"] == null)
                {
                    TempData["Message"] = "Session Expired..! Please SignIn To Access your profile";
                    return RedirectToAction("SignIn", "Login");
                }
                string LinkId = Session["LinkId"].ToString();
                model = objsettings.GetAffiliateLinkDetails(LinkId);
                return View(model);
            }
            catch(Exception ex)
            {
                throw;
            }
        }



        [HttpPost]
        public ActionResult ResetPassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            try
            {
                model.EmailId = Session["EmailId"].ToString();
                model.Password = CurrentPassword;
                var response = objsettings.ChangePassword(model, NewPassword, ConfirmPassword);
                //if (response == "success")
                //    return "success";
                //else return "error";
                ViewBag.ResetMessage = response;

                return Json(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateUser(string UserName,string Gender,string PhoneNo, string City)
        {
            try
            {
                usermodel.UserName = UserName;
                usermodel.Gender = Gender;
                usermodel.EmailId = Session["EmailId"].ToString();
                usermodel.PhoneNo = PhoneNo;
                usermodel.City = City;
                usermodel.AffiliateLinkId = Session["LinkId"].ToString();
                registermodel.FullName = UserName;
                registermodel.PhoneNo = PhoneNo;
                registermodel.EmailId = Session["EmailId"].ToString();
                registermodel.AffiliateLinkId = Session["LinkId"].ToString();
                string response1 = objsettings.UserDetails(usermodel);
                string response2 = objsettings.UpdateRegister(registermodel);
                if (response1 == "Success" && response2 == "Success")
                    return Json(response1);
                else return Json("Failure");
            }catch(Exception ex)
            {
                throw;
            }
            
        }

        [HttpPost]
        public ActionResult GetUserDetails()
        {
            try
            {
                string Username = Session["EmailId"].ToString();
                model = objsettings.GetRegisterDetails(Username);
                usermodel = objsettings.getUserDetails(Username);
                if (usermodel != null)
                    return Json(new { UserName = model.FullName, PhoneNo = model.PhoneNo, Gender = usermodel.Gender, City = usermodel.City });
                else
                    return Json(new { UserName = model.FullName, PhoneNo = model.PhoneNo, Gender = "", City = "" });
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }

}