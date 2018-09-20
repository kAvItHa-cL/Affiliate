using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EEAffiliate.Models;
using EEAffiliate.DAL;

namespace EEAffiliate.Controllers
{
    public class DashBoardController : Controller
    {
        DashBoardModel dashboardmodel = new DashBoardModel();
        DashBoardDal objdashboard = new DashBoardDal();
        List<OrganiserSale> salemodel = new List<OrganiserSale>();
        // GET: DashBoard
        public ActionResult DashBoard()
        {

            try
            {
                string temp = "";
                //List<string> LeadsData = new List<string>();
                List<string> ConversionData = new List<string>();
                List<string> LabelData = new List<string>();

                //string userName = Session["EmailId"].ToString();
                if (Session["EmailId"] == null)
                {
                    TempData["Message"] = "Session Expired..! Please SignIn To Access your profile";
                    return RedirectToAction("SignIn", "Login");
                }
                string LinkId = Session["LinkId"].ToString();


                List<OrganiserSale> sale = new List<OrganiserSale>();
                List<UserView> view = new List<UserView>();
                sale = objdashboard.GetSalesLine(LinkId.ToString());
                //view = objdashboard.GetViewLine(LinkId);
                foreach (var item in sale)
                {
                    ConversionData.Add(item.Sales.ToString());
                    temp = String.Format("{0:m}", item.Date);
                    LabelData.Add(temp);


                }
                //foreach(var item in  view)
                //{
                //    LeadsData.Add(item.ViewId.ToString());
                //}

                //dashboardmodel.LeadsData = LeadsData;
                dashboardmodel.LabelData = LabelData;
                dashboardmodel.ConversionData = ConversionData; ;





                //Get Commission
                int Sum = 0;
                WalletDal objwallet = new WalletDal();
                string EmailId = Session["EmailId"].ToString();

                //Get Sales Details
                salemodel = objwallet.GetDetails(LinkId);
                foreach (var item in salemodel)
                {
                    int AffiliateCommission = (int)item.Commission * 10 / 100;
                    item.Commission = AffiliateCommission;
                    Sum = (int)(Sum + item.Commission);
                }

                //Return DashBoard Values
                dashboardmodel.Commission = Sum;
                dashboardmodel.Settled = objdashboard.GetSettled(LinkId);
                dashboardmodel.Sales = objdashboard.GetSales(LinkId);
                dashboardmodel.Traffic = objdashboard.GetTraffic(LinkId);
                return View(dashboardmodel);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}