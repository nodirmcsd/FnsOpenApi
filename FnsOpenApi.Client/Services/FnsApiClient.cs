﻿using System.Linq;
using System.Xml.Linq;
using FnsOpenApi.Client.Interfaces;
using FnsOpenApi.Client.Models;
using FnsOpenApi.Client.Models.ReceiptResponse;
using FnsOpenApi.Client.Requests;
using FnsOpenApi.Client.Response;
using FnsOpenApi.Client.Utils;
using Newtonsoft.Json;

namespace FnsOpenApi.Client.Services
{
    public class FnsApiClient : IFnsApiClient
    {
        private readonly OpenApiClient _openApiClient;

        public FnsApiClient(OpenApiClient openApiClient)
        {
            _openApiClient = openApiClient;
        }
        
        public string GetAuthToken(string masterToken)
        {
            return _openApiClient.GetAuthToken(masterToken);
        }

        public ReceiptCheck CheckReceipt(string token, Receipt receipt, string appClientId)
        {
            var request = new CheckTicketRequest
            {
                GeoInfo = new GeoInfo
                {
                    Latitude = 1.0,
                    Longitude = 1.0
                },
                CheckTicketInfo = new CheckTicketInfo
                {
                    TypeOperation = receipt.Operation,
                    FiscalDocumentId = receipt.Fp.Trim(),
                    Fn = receipt.Fn.Trim(),
                    FiscalSign = receipt.Fd.Trim(),
                    Date = receipt.Date.ToReceiptDate(),
                    Sum = receipt.Sum.ToReceiptAmount()
                }
            };

            var result = new ReceiptCheckResult();

            XNamespace tns = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0";

            var xmlResponse = _openApiClient.SendMessage(token, request, appClientId);
            var response = XDocument.Parse(xmlResponse);

            result.Code = response.Descendants(tns + "Code")
                .Select(x => x.Value)
                .FirstOrDefault();

            result.Message = response.Descendants(tns + "Message")
                .Select(x => x.Value)
                .FirstOrDefault();

            return new ReceiptCheck
            {
                IsOk = result.Code == "200",
                Message = result.Message
            };
        }

        public ReceiptDetails GetReceiptDetails(string token, Receipt receipt, string appClientId)
        {
            var request = new GetTicketRequest
            {
                GeoInfo = new GeoInfo
                {
                    Latitude = 1.0,
                    Longitude = 1.0
                },
                GetTicketInfo = new GetTicketInfo
                {
                    TypeOperation = receipt.Operation,
                    FiscalDocumentId = receipt.Fp.Trim(),
                    Fn = receipt.Fn.Trim(),
                    FiscalSign = receipt.Fd.Trim(),
                    Date = receipt.Date.ToReceiptDate(),
                    Sum = receipt.Sum.ToReceiptAmount()
                }
            };

            var xmlResponse = _openApiClient.SendMessage(token, request, appClientId);

            var result = xmlResponse.FromXmlString<GetTicketResponse>();
            var retVal = JsonConvert.DeserializeObject<ReceiptDetails>(result.Result.Ticket);

            retVal = retVal.TrimAllStringProperties();

            return retVal;

        }
    }
}
