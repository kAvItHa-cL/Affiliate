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
    
    public partial class AffiliateRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AffiliateRegister()
        {
            this.AffiliateCashOuts = new HashSet<AffiliateCashOut>();
            this.AffiliateContactUs = new HashSet<AffiliateContactU>();
            this.AffiliateUserDetails = new HashSet<AffiliateUserDetail>();
            this.UserRegisters = new HashSet<UserRegister>();
            this.UserViews = new HashSet<UserView>();
        }
    
        public string AffiliateLinkId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ShortURL { get; set; }
        public string ActivationCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AffiliateCashOut> AffiliateCashOuts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AffiliateContactU> AffiliateContactUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AffiliateUserDetail> AffiliateUserDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRegister> UserRegisters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserView> UserViews { get; set; }
    }
}
