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
    
    public partial class StockRoom
    {
        public StockRoom()
        {
            this.CheckingAccounts = new HashSet<CheckingAccount>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockValue { get; set; }
        public int EntryValue { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public string OperationType { get; set; }
    
        public virtual ICollection<CheckingAccount> CheckingAccounts { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
