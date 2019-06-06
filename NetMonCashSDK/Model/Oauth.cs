using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    class Oauth
    {
        public String access_token { get; set; }
        public String token_type { get; set; }
        public String expires_in { get; set; }
        public String scope { get; set; }
        public String jti { get; set; }

        public bool isExpired()
        {
            return true;
        }
    }
}
