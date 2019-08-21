using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    public class PaymentToken
    {
        public String token { get; set; }
        public String created { get; set; }
        public String expired { get; set; }
    }
}
