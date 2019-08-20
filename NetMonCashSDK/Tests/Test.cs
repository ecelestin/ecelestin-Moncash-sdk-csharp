using NetMonCashSDK.Http;
using NetMonCashSDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Tests
{
    class Test
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n-- TEST --\n");

            ApiService apiService = new ApiService(
                "c1bf0a27d6bbb217a599c9e25480c11d",
                "oHrr4tbnB1PH0uz6VQNUvVVDNVNvk0WiIXZWBAed4-CBCwilT8yUdS87AZoPrtqN",
                Constants.SANDBOX
                );

            PaymentCreatorTest(apiService);

            CaptureByTransactionIdTest(apiService);

            CaptureByOrderIdTest(apiService);

            Console.WriteLine("\n-- END --\n");
            Console.ReadKey();
        }

        /*
        * Test Payment creator 
        */
        private static void PaymentCreatorTest(ApiService apiService)
        {

            try
            {
                long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                var payment = new Payment($"{milliseconds}", 500);
                PaymentCreator creator = apiService.paymentCreator(payment).Result;

                Console.WriteLine("\nTest Payment creator\n");

                if (creator.status != null && creator.status.Equals($"{(int)HttpStatusCode.Accepted}"))
                {
                    Console.WriteLine("redirect to the link below");
                    Console.WriteLine(creator.redirectUri());
                }
                else if (creator.status == null)
                {
                    Console.WriteLine(creator.error);
                    Console.WriteLine(creator.error_description);
                }
                else
                {
                    Console.WriteLine(creator.status);
                    Console.WriteLine(creator.error);
                    Console.WriteLine(creator.message);
                    Console.WriteLine(creator.path);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*
        * Test PaymentCapture by TransactionId
        */
        private static void CaptureByTransactionIdTest(ApiService apiService)
        {
            try
            {
                PaymentCapture capture =  apiService.paymentCapture(new TransactionId("12874819")).Result;

                Console.WriteLine("\nTest PaymentCapture by TransactionId\n");

                if (capture.status != null && capture.status.Equals($"{(int)HttpStatusCode.OK}"))
                {
                    Console.WriteLine("Transaction");
                    Console.WriteLine(capture.payment.message);
                    Console.WriteLine($"TransactionId: {capture.payment.transaction_id}");
                    Console.WriteLine($"Payer: {capture.payment.payer}");
                    Console.WriteLine($"Amount: {capture.payment.cost}");
                }
                else
                {
                    Console.WriteLine(JsonConvert.SerializeObject(capture));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*
        * Test PaymentCapture by OrderId
        */
        public static void CaptureByOrderIdTest(ApiService apiService)
        {
            try
            {
                PaymentCapture capture = apiService.paymentCapture(new OrderId("9876543210")).Result;

                Console.WriteLine("\nTest PaymentCapture by OrderId\n");

                if (capture.status != null && capture.status.Equals($"{(int)HttpStatusCode.OK}"))
                {
                    Console.WriteLine("Transaction");
                    Console.WriteLine(capture.payment.message);
                    Console.WriteLine($"TransactionId: {capture.payment.transaction_id}");
                    Console.WriteLine($"Payer: {capture.payment.payer}");
                    Console.WriteLine($"Amount: {capture.payment.cost}");
                }
                else
                {
                    Console.WriteLine(JsonConvert.SerializeObject(capture));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
           

    }
}
