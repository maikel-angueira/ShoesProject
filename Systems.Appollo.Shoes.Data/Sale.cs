//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Systems.Appollo.Shoes.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public Sale()
        {
            this.CheckingAccounts = new HashSet<CheckingAccount>();
            this.SaleProducts = new HashSet<SaleProduct>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ClientId { get; set; }
        public System.DateTime DateOfSale { get; set; }
        public Nullable<int> StoreId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<CheckingAccount> CheckingAccounts { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
