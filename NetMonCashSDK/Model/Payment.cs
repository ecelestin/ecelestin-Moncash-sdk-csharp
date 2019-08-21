using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    public class Payment
    {
        public String orderId { get; set; }
        public double amount { get; set; }

        public Payment(String orderId, double amount)
        {
            this.orderId = orderId;
            this.amount = amount;
        }
    }
}
