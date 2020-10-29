using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    class Variables
    {
        public static int _CashierId;
        public static int _CashierFactoryId;
        public static string _CashierEPF;
        public static string _CashierFactoryName;
        public static List<string> _ListOfNotAvailableItemsWhenPurchase = new List<string>();
    }
}
