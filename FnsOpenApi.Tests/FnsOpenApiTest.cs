using System;
using FnsOpenApi.Domain;
using FnsOpenApi.Domain.Interfaces;
using FnsOpenApi.Domain.Models;
using FnsOpenApi.Domain.Utils;
using FnsOpenApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnsOpenApi.Tests
{



    [TestClass]
    public class FnsOpenApiTest
    {
        private const string MasterToken = "";

        private const string ClientAppId = "YOU_APPLICATION_NAME";

        [TestMethod]
        public void TestGetAuthToken()
        {
            IFnsOpenApi api = new Services.FnsOpenApi(new OpenApiClient(new LogWriter()));
            var token = api.GetAuthToken(MasterToken);
            Assert.IsTrue(!string.IsNullOrEmpty(token));
            Console.WriteLine(token);
        }

        [TestMethod]
        public void TestCheckReceipt()
        {
            IFnsOpenApi api = new Services.FnsOpenApi(new OpenApiClient(new LogWriter()));
            var token = api.GetAuthToken(MasterToken);
            Assert.IsTrue(!string.IsNullOrEmpty(token));
            Console.WriteLine(token);
            var receipt = new Receipt
            {
                Date = new DateTime(2020, 1, 18, 15, 46, 0),
                Fp = "54411",
                Fd = "872811111",
                Fn = "9284000100258875",
                Sum = 225.40,
                Operation = 1
            };

            var result = api.CheckReceipt(token, receipt, ClientAppId);
            Console.WriteLine(result.IsOk);
            Console.WriteLine(result.Message);
        }


        [TestMethod]
        public void TestGetReceiptDetails()
        {
            IFnsOpenApi api = new Services.FnsOpenApi(new OpenApiClient(new LogWriter()));
            var token = api.GetAuthToken(MasterToken);
            Assert.IsTrue(!string.IsNullOrEmpty(token));
            Console.WriteLine(token);
            var receipt = new Receipt
            {
                Date = new DateTime(2020, 1, 18, 15, 46, 0),
                Fp = "54411",
                Fd = "872811111",
                Fn = "9284000100258875",
                Sum = 225.40,
                Operation = 1
            };

            var result = api.GetReceiptDetails(token, receipt, ClientAppId);
            Console.WriteLine(result.ToJson());
        }
    }
}
