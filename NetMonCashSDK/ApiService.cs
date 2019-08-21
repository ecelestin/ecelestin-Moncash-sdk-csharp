using NetMonCashSDK.Http;
using NetMonCashSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace NetMonCashSDK
{
    public class ApiService
    {
        public static readonly HttpClient client = new HttpClient();

        private Oauth oauth;

        public String clientId { get; set; }
        public String clientSecret { get; set; }
        public String mode { get; set; }

        public ApiService(String _key, String _sercetKey, String _mode)
        {
            clientId = _key;
            clientSecret = _sercetKey;
            mode = _mode;
        }


        private async Task<Oauth> getAccessToken()
        {
            if (oauth != null && oauth.isExpired() == false)
                return oauth;

            var encodedData = System.Convert.ToBase64String(
                        System.Text.Encoding.GetEncoding("ISO-8859-1")
                          .GetBytes(clientId + ":" + clientSecret)
                        );
            var base64 = "Basic " + encodedData;

            var url = "";

            if (mode.Equals(Constants.SANDBOX))
                url = Constants.REST_SANDBOX_ENDPOINT;
            else if (mode.Equals(Constants.LIVE))
                url = Constants.REST_LIVE_ENDPOINT;
            else
                throw new ArgumentException($"Mode must be {Constants.SANDBOX} or {Constants.LIVE}");

            url += Constants.OAUTH_TOKEN_URI;
            

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(Constants.HTTP_ACCEPT_HEADER, Constants.HTTP_APPLICATION_JSON);
            client.DefaultRequestHeaders.Add(Constants.HTTP_AUTHORIZATION_HEADER, base64);

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("scope", "read,write"));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            var res = await client.PostAsync(url, new FormUrlEncodedContent(keyValues));
            var resContent = await res.Content.ReadAsStringAsync();
            
            oauth = JsonConvert.DeserializeObject<Oauth>(resContent);

            return oauth;
        }

        public async Task<String> getAuthorizationOauth()
        {
            Oauth oauth = await getAccessToken();

            return $"{oauth.token_type} {oauth.access_token}";
        }


        public async Task<PaymentCreator> paymentCreator(Payment payment)
        {
            var url = "";

            if (mode.Equals(Constants.SANDBOX))
                url = Constants.REST_SANDBOX_ENDPOINT;
            else if (mode.Equals(Constants.LIVE))
                url = Constants.REST_LIVE_ENDPOINT;
            else
                throw new ArgumentException($"Mode must be {Constants.SANDBOX} or {Constants.LIVE}");

            url += Constants.PAYMENT_CREATOR_URI;

            var token = await getAuthorizationOauth();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(Constants.HTTP_ACCEPT_HEADER, Constants.HTTP_APPLICATION_JSON);
            //client.DefaultRequestHeaders.Add(Constants.HTTP_CONTENT_TYPE_HEADER, Constants.HTTP_APPLICATION_JSON);
            client.DefaultRequestHeaders.Add(Constants.HTTP_AUTHORIZATION_HEADER, token);

            var requestJson = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            var res = await client.PostAsync(url, requestJson);
            var resContent = await res.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<PaymentCreator>(resContent);
        }


        public async Task<PaymentCapture> paymentCapture(TransactionId transactionId)
        {
            var url = "";

            if (mode.Equals(Constants.SANDBOX))
                url = Constants.REST_SANDBOX_ENDPOINT;
            else if (mode.Equals(Constants.LIVE))
                url = Constants.REST_LIVE_ENDPOINT;
            else
                throw new ArgumentException($"Mode must be {Constants.SANDBOX} or {Constants.LIVE}");

            url += Constants.PAYMENT_TRANSACTION_URI;

            var token = await getAuthorizationOauth();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(Constants.HTTP_ACCEPT_HEADER, Constants.HTTP_APPLICATION_JSON);
            //client.DefaultRequestHeaders.Add(Constants.HTTP_CONTENT_TYPE_HEADER, Constants.HTTP_APPLICATION_JSON);
            client.DefaultRequestHeaders.Add(Constants.HTTP_AUTHORIZATION_HEADER, token);

            var requestJson = new StringContent(JsonConvert.SerializeObject(transactionId), Encoding.UTF8, "application/json");

            var res = await client.PostAsync(url, requestJson);
            var resContent = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaymentCapture>(resContent);
        }

        public async Task<PaymentCapture> paymentCapture(OrderId orderId)
        {
            var url = "";

            if (mode.Equals(Constants.SANDBOX))
                url = Constants.REST_SANDBOX_ENDPOINT;
            else if (mode.Equals(Constants.LIVE))
                url = Constants.REST_LIVE_ENDPOINT;
            else
                throw new ArgumentException($"Mode must be {Constants.SANDBOX} or {Constants.LIVE}");

            url += Constants.PAYMENT_ORDER_URI;

            var token = await getAuthorizationOauth();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(Constants.HTTP_ACCEPT_HEADER, Constants.HTTP_APPLICATION_JSON);
            //client.DefaultRequestHeaders.Add(Constants.HTTP_CONTENT_TYPE_HEADER, Constants.HTTP_APPLICATION_JSON);
            client.DefaultRequestHeaders.Add(Constants.HTTP_AUTHORIZATION_HEADER, token);

            var requestJson = new StringContent(JsonConvert.SerializeObject(orderId), Encoding.UTF8, "application/json");

            var res = await client.PostAsync(url, requestJson);
            var resContent = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaymentCapture>(resContent);
        }


    }
}
