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
    
    public partial class OrganiserDiscount
    {
        public string Username { get; set; }
        public int EventId { get; set; }
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
        public string Code { get; set; }
        public string StartsAt { get; set; }
        public string EndsAt { get; set; }
    
        public virtual OrganiserEvent OrganiserEvent { get; set; }
        public virtual OrganiserRegister OrganiserRegister { get; set; }
    }
}
