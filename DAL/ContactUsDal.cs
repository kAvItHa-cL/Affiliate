using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEAffiliate.DAL
{
    public class ContactUsDal
    {

        internal string SaveContact(AffiliateContactU model)
        {
            try
            {
                GtTestEEEntities dbContext = new GtTestEEEntities();
                dbContext.AffiliateContactUs.Add(model);
                dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Failure";
                throw;
            }

        }
    }
}