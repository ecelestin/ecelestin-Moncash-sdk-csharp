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
    class ApiService
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

        //public ApiService(String clientId, String clientSecret)
        //{
        //    new ApiService(clientId, clientSecret, Constants.SANDBOX);
        //}

        public async Task<Oauth> getAccessToken()
        {
            if (oauth != null && oauth.isExpired() == false)
                return oauth;
           

            var encodedData = System.Convert.ToBase64String(
                        System.Text.Encoding.GetEncoding("ISO-8859-1")
                          .GetBytes(clientId + ":" + clientSecret)
                        );
            var base64 = "Basic " + encodedData;

            Console.WriteLine(base64);

            var content = new StringContent("scope=read,write&grant_type=client_credentials");

            var url = "";

            if (mode.Equals(Constants.SANDBOX))
                url = Constants.REST_SANDBOX_ENDPOINT;
            else if (mode.Equals(Constants.LIVE))
                url = Constants.REST_LIVE_ENDPOINT;

            url += Constants.OAUTH_TOKEN_URI;
            

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(Constants.HTTP_ACCEPT_HEADER, Constants.HTTP_APPLICATION_JSON);
            client.DefaultRequestHeaders.Add(Constants.HTTP_AUTHORIZATION_HEADER, base64);

            var res = await client.PostAsync(url, content);
            var resContent = await res.Content.ReadAsStringAsync();

            if (res.StatusCode != HttpStatusCode.OK)
                throw new MonCashRestException(resContent);


            oauth = JsonConvert.DeserializeObject<Oauth>(resContent);

            return oauth;
        }


       // public async Task<>


    }
}
