using NetMonCashSDK.Http;
using NetMonCashSDK.Model;
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


            /*
             * Test Payment creator 
             */
            try
            {
                Console.WriteLine("\nTest Payment creator\n");
                long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                var payment = new Payment($"{milliseconds}", 50);
                Console.WriteLine(JsonConvert.SerializeObject(apiService.paymentCreator(payment).Result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            /*
             * Test PaymentCapture by TransactionId
             */
            try
            {
                Console.WriteLine("\nTest PaymentCapture by TransactionId\n");
                Console.WriteLine(JsonConvert.SerializeObject(apiService.paymentCapture(new TransactionId("1555945998145")).Result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            /*
             * Test PaymentCapture by OrderId
             */
            try
            {
                Console.WriteLine("\nTest PaymentCapture by OrderId\n");
                Console.WriteLine(JsonConvert.SerializeObject(apiService.paymentCapture(new OrderId("1555952605")).Result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.ReadKey();
        }
    }
}
