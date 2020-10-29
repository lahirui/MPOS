using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPOS.Models
{
    public class ModelReplenishments
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        public Nullable<decimal> Quantity { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int FactoryId { get; set; }

    }
}