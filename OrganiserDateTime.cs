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
    
    public partial class OrganiserDateTime
    {
        public int EventId { get; set; }
        public int DatetimeId { get; set; }
        public Nullable<System.DateTime> StartDatetime { get; set; }
        public string EndDatetime { get; set; }
        public string Status { get; set; }
    
        public virtual OrganiserEvent OrganiserEvent { get; set; }
    }
}
