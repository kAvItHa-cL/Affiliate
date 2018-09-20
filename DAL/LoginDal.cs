using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEAffiliate.DAL
{
    public class LoginDal
    {
        GtTestEEEntities dbContext = new GtTestEEEntities();

        internal string Checklogin(AffiliateRegister model1)
        {
            try
            {

                if (model1.EmailId != "" && model1.Password != "")
                {
                    var loginresult = dbContext.AffiliateRegisters.Where(s => s.EmailId == model1.EmailId && s.Password == model1.Password).FirstOrDefault();
                    if (loginresult != null)
                    {
                        return "success";
                    }

                    else
                    {
                        return "False";
                    }
                }
                else return "empty";

            }
            catch (Exception)
            {
                return "False";
                throw;
            }
        }
        //internal string GetUserName(AffiliateRegister model)
        //{
        //    var UserName = dbContext.AffiliateRegisters.Where(s => s.EmailId == model.EmailId).Select(s => s.FullName).FirstOrDefault(); ;
        //    return UserName.ToString();


        //}
        //internal string GetPhoneNo(AffiliateRegister model)
        //{
        //    var PhoneNo = dbContext.AffiliateRegisters.Where(s => s.EmailId == model.EmailId).Select(s => s.PhoneNo).FirstOrDefault(); ;
        //    return PhoneNo.ToString(); ;

        //}

        internal string GetLinkId(AffiliateRegister model)
        {
            try
            {
                var LinkId = dbContext.AffiliateRegisters.Where(s => s.EmailId == model.EmailId).Select(s => s.AffiliateLinkId).FirstOrDefault(); ;
                return LinkId.ToString(); ;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}