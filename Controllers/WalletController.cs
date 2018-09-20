using EEAffiliate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAffiliate.Controllers
{
    public class WalletController : Controller
    {
        List<OrganiserSale> salemodel = new List<OrganiserSale>();
        List<AffiliateCashOut> cashoutmodel = new List<AffiliateCashOut>();


        // GET: Wallet
        public ActionResult Wallet()
        {
            try {
                if (Session["EmailId"] == null)
                {
                    TempData["Message"] = "Session Expired..! Please SignIn To Access your profile";
                    return RedirectToAction("SignIn", "Login");
                }
                int Sum = 0, credit = 0;
                WalletDal objwallet = new WalletDal();
                string EmailId = Session["EmailId"].ToString();
                string LinkId = Session["LinkId"].ToString();

                //Get Sales Details
                salemodel = objwallet.GetDetails(LinkId);
                foreach (var item in salemodel)
                {
                    int AffiliateCommission = (int)item.Commission * 10 / 100;
                    item.Commission = AffiliateCommission;
                    Sum = (int)(Sum + item.Commission);
                }

                //GetCashout Details
                cashoutmodel = objwallet.GetCashOutDetails(LinkId);
                foreach (var item in cashoutmodel)
                {
                    int CashOutAmount = (int)item.Amount;
                    credit = (int)(credit + CashOutAmount);
                }
                int Amount = Sum - credit;
                ViewBag.Wallet = Amount;
                return View();
            }
            catch(Exception ex)
            {
                throw;
            }
            }
        }
    }
