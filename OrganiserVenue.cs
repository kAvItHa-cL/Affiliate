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
    
    public partial class OrganiserVenue
    {
        public int EventId { get; set; }
        public string Location { get; set; }
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public Nullable<int> TicketPrice { get; set; }
        public string Comments { get; set; }
        public Nullable<int> Discounts { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string City { get; set; }
    
        public virtual OrganiserEvent OrganiserEvent { get; set; }
    }
}