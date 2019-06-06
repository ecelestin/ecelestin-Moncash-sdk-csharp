using NetMonCashSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    class PaymentCreator: Resource
    {
        public PaymentToken payment_token { get; set; }

        public String redirectUri()
        {
            if (payment_token == null)
                throw new MonCashRestException("paymentToken must not be null");

            return $"{Constants.REDIRECT_URI}?token={payment_token.token}";
        }
    }
}
