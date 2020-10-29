using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPOS.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}