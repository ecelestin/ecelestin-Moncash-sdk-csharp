using NetMonCashSDK.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Tests
{
    class Test
    {
        static void Main(string[] args)
        {
            ApiService apiService = new ApiService(
                "c1bf0a27d6bbb217a599c9e25480c11d",
                "oHrr4tbnB1PH0uz6VQNUvVVDNVNvk0WiIXZWBAed4-CBCwilT8yUdS87AZoPrtqN",
                Constants.SANDBOX
                );

            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(apiService.getAccessToken().Result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            Console.ReadKey();
        }
    }
}
