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
    
    public partial class Color
    {
        public Color()
        {
            this.Products = new HashSet<Product>();
            this.ModelColors = new HashSet<ModelColor>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ModelColor> ModelColors { get; set; }
    }
}
