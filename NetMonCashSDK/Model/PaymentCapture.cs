using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    class PaymentCapture: Resource
    {
        public Transaction payment { get; set; }
    }
}
