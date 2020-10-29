using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPOS.Models
{
    public class ItemsReadyToPurchase
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int EmployeeID { get; set; }
        public int UserId { get; set; }
        public Nullable<decimal> ItemQty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> ItemTotal { get; set; }
    }
}