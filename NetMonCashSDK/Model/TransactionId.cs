using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    public class TransactionId
    {
        public String transactionId { get; set; }

        public TransactionId(String transactionId)
        {
            this.transactionId = transactionId;
        }
    }
}
