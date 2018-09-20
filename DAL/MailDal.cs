using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EEAffiliate.DAL
{
    public class MailDal
    {
        internal void SendMail(AffiliateContactU model)
        {
            try
            {
                var SmtpClient = new SmtpClient();
                string body = "EmailId =" + model.EmailId + "Name = " + model.FullName + "\n Phone =  " + model.PhoneNo + "\n Message =  " + model.Message + "\n Date = " + DateTime.Now;
                SmtpClient.Send("support@eventserica.com", "support@eventserica.com", "Affiliate Equiry Contact", body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal void SendRegisterMail(AffiliateRegister model)
        {
            try
            {
                var SmtpClient = new SmtpClient();
                string body = "Email = " + model.EmailId + "\n Password =  " + model.Password + "\n FullName =  " + model.FullName + "\n Register Date = " + DateTime.Now;
                SmtpClient.Send("support@eventserica.com", "support@eventserica.com", "Affiliate Register Form", body);
            }
            catch (Exception ex)
            { throw; }
            }
        internal void WelcomeSendMail(string user)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())

                {
                    string body = "Hello Wanderer!";
                    using (System.IO.StreamReader Reader = new System.IO.StreamReader(HttpContext.Current.Server.MapPath("~/welcome.html")))
                    {
                        body = Reader.ReadToEnd();
                    }
                    mailMessage.From = new MailAddress("support@eventserica.com");

                    mailMessage.Subject = "Thanks for joining EventsErica Community community!";

                    mailMessage.Body = body;

                    mailMessage.IsBodyHtml = true;

                    mailMessage.To.Add(new MailAddress(user));
                    var SmtpClient = new SmtpClient();

                    SmtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            { throw; }
        }
            internal void SendActivationCode(AffiliateRegister model, string code)
            {
            try
            {
                string url = "http://affiliate01.eventserica.com//Activate/Verification?user=" + model.EmailId + "&code=" + code;

                using (MailMessage mailMessage = new MailMessage())
                {
                    string body = "Hello = " + model.FullName;
                    using (System.IO.StreamReader Reader = new System.IO.StreamReader(HttpContext.Current.Server.MapPath("~/Mail/Activate.html")))
                    {
                        body = Reader.ReadToEnd();
                    }
                    body = Regex.Replace(body, "Replacewithurl", url);
                    mailMessage.From = new MailAddress("support@eventserica.com");

                    mailMessage.Subject = "Confirm Your Account!";

                    mailMessage.Body = body;

                    mailMessage.IsBodyHtml = true;

                    mailMessage.To.Add(new MailAddress(model.EmailId));
                    var SmtpClient = new SmtpClient();

                    SmtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            { throw; }
        }
        internal void SendForgotMail(string Username, string id, string guid)
        {
            try { 
            string url = System.Configuration.ConfigurationManager.AppSettings["Forgoturl"];
            url = url + guid;
                using (MailMessage mailMessage = new MailMessage())
                {
                    string body = "Hello!";
                    using (System.IO.StreamReader Reader = new System.IO.StreamReader(HttpContext.Current.Server.MapPath("~/Mail/Forgot.html")))
                    {
                        body = Reader.ReadToEnd();
                    }
                    body = body.Replace("Replacewithcode", url);
                    mailMessage.From = new MailAddress("support@eventserica.com");
                    mailMessage.Subject = "Password Reset";
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(Username));
                    var SmtpClient = new SmtpClient();
                    SmtpClient.Send(mailMessage);
                }
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
    }
