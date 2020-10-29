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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItemPurchases = new HashSet<ItemPurchase>();
            this.ItemTransactions = new HashSet<ItemTransaction>();
            this.EmployeeAdjustments = new HashSet<EmployeeAdjustment>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ItemTypeId { get; set; }
        public Nullable<int> FactoryId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> UnitCapacity { get; set; }
        public Nullable<decimal> DaySellingQty { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> MetricId { get; set; }
    
        public virtual Factory Factory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemPurchase> ItemPurchases { get; set; }
        public virtual ItemType ItemType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTransaction> ItemTransactions { get; set; }
        public virtual Metric Metric { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeAdjustment> EmployeeAdjustments { get; set; }
    }
}