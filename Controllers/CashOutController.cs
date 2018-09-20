using EEAffiliate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAffiliate.Controllers
{
    public class CashOutController : Controller
    {
        AffiliateCashOut model = new AffiliateCashOut();
        CashOutDal objCashout =new CashOutDal();
        List<OrganiserSale> salemodel = new List<OrganiserSale>();
        List<AffiliateCashOut> cashoutmodel = new List<AffiliateCashOut>();

        // GET: CashOut
        public ActionResult CashOut()
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
        public ActionResult CashOut(string AccountHolder,string AccountNo,string ConfirmAccountNo,string IFSC,int Amount)
        {
            try
            {
                model.AccountHolder = AccountHolder;
                model.AccountNo = AccountNo;
                model.ConfirmAccountNo = ConfirmAccountNo;
                model.IFSC = IFSC;
                model.Amount = Amount;
                model.Date = DateTime.Now;
                model.Status = "Proceeding";
                model.AffiliateLinkId = Session["LinkId"].ToString();
                model.EmailId = Session["EmailId"].ToString();
                // To Get Wallet Balance
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


                //int cashoutsum = objCashout.GetCashOutDetails(LinkId,model);
                //int Balance = Sum - cashoutsum;
                cashoutmodel = objwallet.GetCashOutDetails(LinkId);
                foreach (var item in cashoutmodel)
                {
                    int CashOutAmount = (int)item.Amount;
                    credit = (int)(credit + CashOutAmount);
                }
                int Balance = Sum - credit;

                if (Balance > 10)//
                {
                    if (Amount < Balance)
                    {

                        string response = objCashout.ProceedCashOut(model);

                        if (response == "Success")
                        {
                            ViewBag.SuccessMessage = "Success";
                            return View();

                        }
                        else
                        {
                            ViewBag.Message = "Invalid Inputs, Please try again !";
                            return View();
                        }

                    }
                    else
                    {
                        ViewBag.Message = "You Dont have Sufficient Balance., Please Check your Wallet..!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "You Dont have Minimum Balance., Please Check your Wallet..!";
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public ActionResult CashOutDetails()
        {
            try
            {
                string LinkId = Session["LinkId"].ToString();
                cashoutmodel = objCashout.GetPreviousCashOuts(LinkId);
                return View(cashoutmodel);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}