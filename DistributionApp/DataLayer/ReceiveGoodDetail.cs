//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistributionApp.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReceiveGoodDetail
    {
        public int ReceiveGoodDetailId { get; set; }
        public Nullable<int> ReceiveGoodId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string BatchNumber { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ReceiveGood ReceiveGood { get; set; }
    }
}
