using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEAffiliate.DAL
{
    public class WalletDal
    {
        GtTestEEEntities dbContext = new GtTestEEEntities();

        internal List<OrganiserSale> GetDetails(string LinkId)
        {
            try
            {
                //var Linkid = dbContext.AffiliateLinks.Where(t => t.EmailId == EmailId).Select(t => t.AffiliateLinkId).FirstOrDefault();
                var result = dbContext.OrganiserSales.Where(s => s.AffiliateLinkId == LinkId).ToList<OrganiserSale>();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal List<AffiliateCashOut> GetCashOutDetails(string LinkId)
        {
            try
            {
                //var Linkid = dbContext.AffiliateLinks.Where(t => t.EmailId == EmailId).Select(t => t.AffiliateLinkId).FirstOrDefault();
                var result = dbContext.AffiliateCashOuts.Where(s => s.AffiliateLinkId == LinkId).ToList<AffiliateCashOut>();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    }
