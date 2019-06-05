using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Http
{
    class Constants
    {
        public static String HTTP_CONTENT_TYPE_HEADER { get { return "Content-Type"; } }
        public static String HTTP_AUTHORIZATION_HEADER { get { return "Authorization"; } }
        public static String HTTP_ACCEPT_HEADER { get { return "Accept"; } }
        public static String HTTP_APPLICATION_JSON { get { return "application/json"; } }

        public static String OAUTH_TOKEN_URI { get { return "/oauth/token"; } }
        public static String PAYMENT_CREATOR_URI { get { return "/v1/CreatePayment"; } }
        public static String PAYMENT_TRANSACTION_URI { get { return "/v1/RetriveTransactionPayment"; } }
        public static String PAYMENT_ORDER_URI { get { return "/v1/RetriveOrderPayment"; } }

        public static String REST_SANDBOX_ENDPOINT { get { return "http://200.113.192.182:8080/Api"; } }
        public static String REST_LIVE_ENDPOINT { get { return "http://localhost:8080"; } }
        public static String REDIRECT_URI { get { return "http://localhost:8080"; } }
        public static String SANDBOX { get { return "sandbox"; } }

        public static String LIVE { get { return "live"; } }
        public static String URL_KEY { get { return "url"; } }
        public static String METHOD_KEY { get { return "method"; } }
        
    }
}
