using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EEAffiliate.DAL;
using EEAffiliate.Models;

namespace EEAffiliate.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        //OrganiserSale salemodel = new OrganiserSale();
        List<OrganiserSale> salemodel = new List<OrganiserSale>();
        public ActionResult Sales()
        {
            try {
                if (Session["EmailId"] == null)
                {
                    TempData["Message"] = "Session Expired..! Please SignIn To Access your profile";
                    return RedirectToAction("SignIn", "Login");
                }

                SalesDal objsale = new SalesDal();
                string EmailId = Session["EmailId"].ToString();
                string LinkId = Session["LinkId"].ToString();

                salemodel = objsale.GetSalesDetails(LinkId);
                foreach (var item in salemodel)
                {
                    int AffiliateCommission = (int)item.Commission * 10 / 100;
                    item.Commission = AffiliateCommission;



                }
                //salemodel.TicketPrice = 500;
                // salemodel.Commission = salemodel.TicketPrice - 200;
                return View(salemodel);
            }
            catch(Exception ex)
            {
                throw;
            }
            }
    }
}