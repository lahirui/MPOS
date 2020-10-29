using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPOS.Models
{
    public class CustomerDashboard
    {
        public string Customer { get; set; }
        public string Item { get; set; }
        public string UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
    }
}