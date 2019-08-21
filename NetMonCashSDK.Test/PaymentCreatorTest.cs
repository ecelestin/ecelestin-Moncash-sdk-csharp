using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMonCashSDK.Http;
using NetMonCashSDK.Model;
using System.Net;

namespace NetMonCashSDK.Test
{
    [TestClass]
    public class PaymentCreatorTest
    {
        [TestMethod]
        public void Create()
        {
            ApiService apiService = new ApiService(CredentialTest.CLIENT_ID, CredentialTest.CLIENT_SECRET, Constants.SANDBOX);

            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            var payment = new Payment($"{milliseconds}", 500);
            PaymentCreator creator = apiService.paymentCreator(payment).Result;

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
    }
}
