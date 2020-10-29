//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPOS.App_Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeAdjustment
    {
        public int ID { get; set; }
        public Nullable<long> EmployeeId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> CashierId { get; set; }
        public Nullable<int> EnteredUserId { get; set; }
        public Nullable<int> TransactionTypeId { get; set; }
        public Nullable<int> FactoryId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> EnteredDate { get; set; }
        public string Remarks { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Item Item { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual User User { get; set; }
    }
}
