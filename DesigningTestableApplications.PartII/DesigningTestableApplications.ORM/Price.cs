//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesigningTestableApplications.ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual Product Product { get; set; }
    }
}
