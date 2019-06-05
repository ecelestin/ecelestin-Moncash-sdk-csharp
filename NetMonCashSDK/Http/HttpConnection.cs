using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Http
{
    class HttpConnection
    {
        public static readonly HttpClient client = new HttpClient();

        public Dictionary<String, String> header { get; set; }
        public String method { get; set; }
    }
}
