using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace EEAffiliate.DAL
{
    public class PasswordDal
    {
        GtTestEEEntities dbContext = new GtTestEEEntities();
        MailDal objmail = new MailDal();
        internal string CheckUser(string EmailId)
        {
           try
            {
                
                var query = dbContext.AffiliateRegisters
                    .Where(p => p.EmailId == EmailId).FirstOrDefault();
                if (query != null)
                {
                    Guid id = Guid.NewGuid();
                    objmail.SendForgotMail(EmailId, id.ToString(), id.ToString());
                    var Register = dbContext.AffiliateRegisters
                   .Where(p => p.EmailId == EmailId).FirstOrDefault();
                    Register.ActivationCode = id.ToString();
                    dbContext.Entry(Register).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return "success";
                }
                else
                {
                    return "Email Not Found!";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal int UpdatePassword(string newPassword, string user)
        {
            try
            {
                int flag = GetUser(user);

                if (flag <= 0)
                {
                    DateTime da = DateTime.Now;
                    AffiliateRegister model = dbContext.AffiliateRegisters.Where(p => p.EmailId == user).FirstOrDefault();
                    model.Password = newPassword;
                    //dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();


                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        private int GetUser(string emailId)
        {
            try
            {
                int flag = dbContext.AffiliateRegisters.Where(p => p.EmailId == emailId).Count();
                return flag;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal string ConfirmPassword(string Password, string code)
        {
            try
            {
                var query = dbContext.AffiliateRegisters
                    .Where(p => p.ActivationCode == code).FirstOrDefault();
                if (query != null)
                {
                    query.Password = Password;
                    query.ConfirmPassword = Password;
                    dbContext.Entry(query).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return"Password Reset Successful.. Please Login to view your profile";
                }
                else
                {
                    return "Invalid Activation Code";
                }
            }
            catch (Exception ex)
            {
                return "failure";
                throw;
            }
        }
    }
}