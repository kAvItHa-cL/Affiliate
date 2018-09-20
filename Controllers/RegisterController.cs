using EEAffiliate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAffiliate.Controllers
{
    public class RegisterController : Controller
    {
        AffiliateRegister model = new AffiliateRegister();
        RegisterDal objregister = new RegisterDal();
        MailDal objMail = new MailDal();
        // GET: Register
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(AffiliateRegister model)
        {
            try
            {

                Guid ActiveId = Guid.NewGuid();
                model.Date = DateTime.Now;
                model.ActivationCode = ActiveId.ToString();
                string uniqueId = objregister.GetRandomString();

                model.AffiliateLinkId = uniqueId;
                string temp = objregister.SaveRegister(model);

                if (temp == "Success")
                {
                    //Guid id = new Guid();
                    //objMail.SendActivationCode(model, id.ToString());
                    objMail.WelcomeSendMail(model.EmailId);
                    objMail.SendRegisterMail(model);

                    Session["User"] = model.EmailId;
                    Session["LinkId"] = model.AffiliateLinkId;
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    ViewBag.Error = "User Exists!";
                    return View();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}