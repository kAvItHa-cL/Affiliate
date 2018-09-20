using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EEAffiliate.DAL
{
    public class DashBoardDal
    {
        GtTestEEEntities dbContext = new GtTestEEEntities();
        public int GetTraffic(string LinkId)
        {
            try
            {
                int trafficcount = (int)dbContext.UserViews.Where(s => s.AffiliateLinkId == LinkId).Count();
                int traffic = trafficcount - 1; ;
                if(traffic < 0)
                { return 0; } else { return traffic;  }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public int GetSales(string LinkId)
            {
            try
            {

                int count = (int)dbContext.OrganiserSales.Where(s => s.AffiliateLinkId == LinkId).Count();
                if (count > 0)
                {
                    int sales = (int)dbContext.OrganiserSales.Where(s => s.AffiliateLinkId == LinkId).Sum(p => p.Sales);
                    return sales;
                }
                else
                    return 0;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
       
        public int GetSettled(string LinkId)
        {
            try
            {
                int count = dbContext.AffiliateCashOuts.Where(s => s.AffiliateLinkId == LinkId).Count();
                if (count > 0)
                {
                    int settled = dbContext.AffiliateCashOuts.Where(s => s.AffiliateLinkId == LinkId).Sum(p => p.Amount);
                    return settled;
                }
                else return 0;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        internal List<OrganiserSale> GetSalesLine(string LinkId)
        {
            try
            {

                var query = dbContext.OrganiserSales
                   .Where(p => p.AffiliateLinkId == LinkId).ToList();
                   

                return query;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}