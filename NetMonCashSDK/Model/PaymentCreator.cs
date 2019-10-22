using NetMonCashSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    public class PaymentCreator: Resource
    {
        public PaymentToken payment_token { get; set; }
        public String mode { get; set; }

        public String redirectUri()
        {
            if (payment_token == null)
                throw new MonCashRestException("paymentToken must not be null");

            if(mode.Equals(Constants.SANDBOX))
                return $"{Constants.SANDBOX_REDIRECT + Constants.GATE_WAY_URI}?token={payment_token.token}";
            else if(mode.Equals(Constants.LIVE_REDIRECT))
                return $"{Constants.LIVE_REDIRECT + Constants.GATE_WAY_URI}?token={payment_token.token}";
            else
                throw new MonCashRestException($"Mode must be {Constants.SANDBOX} or {Constants.LIVE}");
        }
    }
}
