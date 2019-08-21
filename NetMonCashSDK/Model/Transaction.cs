using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    public class Transaction
    {
        public String reference { get; set; }
        public String message { get; set; }
        public String transaction_id { get; set; }
        public String payer { get; set; }
        public double cost { get; set; }
        public String error { get; set; }
    }
}
