using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    class TokenAuthorization
    {
        public String accessToken { get; set; }
        public String tokenSecret { get; set; }

        public TokenAuthorization(String accessToken, String tokenSecret)
        {
            if (accessToken == null || accessToken.Length == 0 || tokenSecret == null || tokenSecret.Length == 0)
                throw new Exception("TokenAuthorization arguments cannot be empty or null");

            this.accessToken = accessToken;
            this.tokenSecret = tokenSecret;
        }
    }
}
