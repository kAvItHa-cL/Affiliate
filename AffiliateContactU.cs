//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EEAffiliate
{
    using System;
    using System.Collections.Generic;
    
    public partial class AffiliateContactU
    {
        public int ContactId { get; set; }
        public string AffiliateLinkId { get; set; }
        public string EmailId { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual AffiliateRegister AffiliateRegister { get; set; }
    }
}
