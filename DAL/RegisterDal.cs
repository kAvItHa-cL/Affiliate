using EEAffiliate.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace EEAffiliate.DAL
{
    public class RegisterDal
    {
        internal string SaveRegister(AffiliateRegister model)
        {
            try
            {
                     int flag = GetUser(model.EmailId);
                
                if (flag <= 0)
                {
                    string longUrl = "http://user01.eventserica.com/?AffiliateLinkId=" + model.AffiliateLinkId;
                    string shortUrl = Shorten(longUrl);
                    model.ShortURL = shortUrl;

                    GtTestEEEntities dbContext = new GtTestEEEntities();
                    dbContext.AffiliateRegisters.Add(model);
                    dbContext.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Exists";
                }
            }
            catch (Exception ex)
            {
                return "Failure";
                throw;
            }

        }
        private int GetUser(string emailId)
        {
            try
            {
                GtTestEEEntities dbContext = new GtTestEEEntities();
                int count = dbContext.AffiliateRegisters.Count(t => t.EmailId == emailId);
                return count;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string GetRandomString()
        {
            try
            {
                string uniqueId = RandomString(6);
                return uniqueId;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            try
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Shorten(string longUrl)
        {
            try
            {
                string url = "https://api-ssl.bitly.com/v3/shorten?access_token=7fb483214f0d6bfc6907e530f7799c63499de088&longUrl=" + longUrl + "&format=json";
                HttpWebRequest bitLy = HttpWebRequest.Create(url) as HttpWebRequest;
                bitLy.Method = "GET";
                bitLy.ContentType = "application/json; charset=utf-8";
                HttpWebResponse YammerResponse = bitLy.GetResponse() as HttpWebResponse;
                //returns a single jArray row
                dynamic resp = JsonConvert.DeserializeObject(
                    new StreamReader(bitLy.GetResponse().GetResponseStream()).ReadToEnd());
                BitlyModel msg = resp.ToObject<BitlyModel>();
                Console.WriteLine(msg.data.url);
                return msg.data.url;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}



