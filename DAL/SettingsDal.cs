using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace EEAffiliate.DAL
{
    public class SettingsDal
    {
        internal string ChangePassword(AffiliateRegister model, string NewPassword, string ConfirmPassword)
        {

            try
            {
                GtTestEEEntities dbContext = new GtTestEEEntities();

                if (model.Password != "" && NewPassword != "" && ConfirmPassword != "")
                {
                    var resetresult = dbContext.AffiliateRegisters.Where(s => s.Password == model.Password && s.EmailId == model.EmailId).FirstOrDefault();
                    if (resetresult != null)
                    {
                        resetresult.Password = NewPassword;
                        resetresult.ConfirmPassword = ConfirmPassword;
                        dbContext.SaveChanges();
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

        internal string UserDetails(AffiliateUserDetail usermodel)
        {
            try {
                
                   
                using (var dbcontext = new GtTestEEEntities())
                {
                    var result = dbcontext.AffiliateUserDetails
                     .Where(e => e.EmailId == usermodel.EmailId).FirstOrDefault();

                    if (result != null)
                    {
                        result.City = usermodel.City;
                        result.UserName = usermodel.UserName;
                        result.Gender = usermodel.Gender;
                        result.PhoneNo = usermodel.PhoneNo;
                        dbcontext.Entry(result).State = System.Data.Entity.EntityState.Modified;
                        dbcontext.SaveChanges();
                        return "Success";

                    }
                    else
                    {
                          GtTestEEEntities dbContext = new GtTestEEEntities();
                        dbContext.AffiliateUserDetails.Add(usermodel);
                        dbContext.SaveChanges();
                        return "Success";
                    }

                }

                //return "success";
            }
            catch (Exception ex)
            {
                return "Failure";
                throw;
            }

        } 
              internal string UpdateRegister(AffiliateRegister registermodel)
        {
            try
            {
               
                       using (var dbcontext = new GtTestEEEntities())
                {
                    var result = dbcontext.AffiliateRegisters
                     .Where(e => e.EmailId == registermodel.EmailId).FirstOrDefault();

                    result.FullName = registermodel.FullName;
                    result.PhoneNo = registermodel.PhoneNo;
                    dbcontext.Entry(result).State = System.Data.Entity.EntityState.Modified;

                    dbcontext.SaveChanges();
                }
                
            return "Success";
            }
            catch (Exception ex)
            {
                return "Failure";
                throw;
            }

        }
        internal AffiliateRegister GetRegisterDetails(string Username)
        {
            try
            {
                GtTestEEEntities dbContext = new GtTestEEEntities();
                var query = dbContext.AffiliateRegisters
                    //.Include("AffiliateUserDetail")
                .Where(p => p.EmailId == Username).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal AffiliateUserDetail getUserDetails(string Username)
        {
            try
            {
                GtTestEEEntities dbContext = new GtTestEEEntities();
                var query = dbContext.AffiliateUserDetails
                //.Include("AffiliateUserDetail")
                .Where(p => p.EmailId == Username).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal AffiliateRegister  GetAffiliateLinkDetails(string LinkId)
        {
            try
            {
                GtTestEEEntities dbContext = new GtTestEEEntities();
                var query = dbContext.AffiliateRegisters
                    
                 .Where(p => p.AffiliateLinkId == LinkId).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }


    }
}





