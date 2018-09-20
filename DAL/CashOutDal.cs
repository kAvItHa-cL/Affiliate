using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEAffiliate.DAL
{
    public class CashOutDal
    {
        GtTestEEEntities dbContext = new GtTestEEEntities();
        internal string ProceedCashOut(AffiliateCashOut model)
        {
            try
            {
                
                dbContext.AffiliateCashOuts.Add(model);
                dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Failure";
                throw;
            }

        }
        public int GetCashOutDetails(string LinkId, AffiliateCashOut model)
        {
            try
            {
                var result = dbContext.AffiliateCashOuts.Where(s => s.AffiliateLinkId == LinkId).Sum(p => p.Amount);

                if (result != 0)
                    return (int)result;
                else return 0;
            }
            catch(Exception ex)
            {
                return 0;
                throw;
            }
        }

        internal List<AffiliateCashOut> GetPreviousCashOuts(string LinkId)
        {
            try
            {
                var result = dbContext.AffiliateCashOuts.Where(s => s.AffiliateLinkId == LinkId).ToList<AffiliateCashOut>();
                return result;
            }
            catch(Exception ex)
            {
                throw;
                
            }
        } 

    }
}