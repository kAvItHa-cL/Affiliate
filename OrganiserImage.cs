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
    
    public partial class OrganiserImage
    {
        public int EventId { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual OrganiserEvent OrganiserEvent { get; set; }
    }
}