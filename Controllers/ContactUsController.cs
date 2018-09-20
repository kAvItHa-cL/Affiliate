using EEAffiliate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAffiliate.Controllers
{
    public class ContactUsController : Controller
    {
        ContactUsDal obcontact = new ContactUsDal();
        AffiliateContactU model = new AffiliateContactU();
        MailDal objmail = new MailDal();
        SettingsDal objsettings = new SettingsDal();
        AffiliateRegister rmodel = new AffiliateRegister();
        // GET: ContactUs
        public ActionResult ContactUs()
        {
            try
            {
                if (Session["EmailId"] == null)
                {
                    TempData["Message"] = "Session Expired..! Please SignIn To Access your profile";
                    return RedirectToAction("SignIn", "Login");
                }
                return View();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult ContactUs(string Message)
        {
            try
            {
                string Username = Session["EmailId"].ToString();
                string LinkId = Session["LinkId"].ToString();
                rmodel = objsettings.GetRegisterDetails(Username);
                model.PhoneNo = rmodel.PhoneNo;
                model.Message = Message;
                model.EmailId = Session["EmailId"].ToString();
                model.AffiliateLinkId = LinkId;
                model.FullName = rmodel.FullName;

                model.Date = DateTime.Now;

                string response = obcontact.SaveContact(model);
                // objmail.SendMail(model);
                if (response == "Success")
                {
                    ViewBag.Message = " Thanks for contacting us! Our representative will call you shortly.";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Something went Wrong, Please try to Contact Us Later";
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