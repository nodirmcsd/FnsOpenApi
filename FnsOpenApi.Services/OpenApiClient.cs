using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using FnsOpenApi.Domain.Interfaces;
using FnsOpenApi.Domain.Utils;

namespace FnsOpenApi.Services
{
    public class OpenApiClient
    {
        private readonly ILogWriter _logWriter;
        private const int ResponseTimeout = 10000;
        private const int ResponseWaitTime = 1000;

        public OpenApiClient(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        /// <summary>
        /// GetToken
        /// </summary>
        /// <param name="masterToken"></param>
        /// <returns></returns>
        public string GetAuthToken(string masterToken)
        {
            var client = new AuthService.OpenApiMessageConsumerServicePortTypeClient();
            var getMessageRequest = new AuthService.GetMessageRequest();
            
            var request = new XmlDocument();
            request.LoadXml("<tns:AuthRequest xmlns:tns=\"urn://x-artefacts-gnivc-ru/ais3/kkt/AuthService/types/1.0\">" +
                            "<tns:AuthAppInfo>" +
                            $"<tns:MasterToken>{masterToken}</tns:MasterToken>" +
                            "</tns:AuthAppInfo>" +
                            "</tns:AuthRequest>");


            getMessageRequest.Message = request.DocumentElement;
            
            var getMessageResponse = client.GetMessageAsync(getMessageRequest)
                .GetAwaiter()
                .GetResult();

            var response = getMessageResponse.Message;

            _logWriter.Trace(response.OuterXml);

            var result = XDocument.Parse(response.InnerXml);

            XNamespace tns = "urn://x-artefacts-gnivc-ru/ais3/kkt/AuthService/types/1.0";
            var token = result.Descendants(tns + "Token")
                .Select(x => x.Value)
                .FirstOrDefault();

            _logWriter.Trace(token);

            return token;
        }
        
        public string SendMessage<T>(string token, T request, string appClientId)
            where T : IOpenApiClientRequest
        {
            var kktServiceClient = new KktService.OpenApiAsyncMessageConsumerServicePortTypeClient();

            using (new OperationContextScope(kktServiceClient.InnerChannel))
            {
                var requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["FNS-OpenApi-Token"] = token;

                requestMessage.Headers["FNS-OpenApi-UserToken"] =
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(appClientId.Trim().ToLowerInvariant()));

                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                var sendMessageRequest = new KktService.SendMessageRequest();

                var xmlRequest = request.ToXmlDocument();

                _logWriter.Trace(request.ToXmlString());

                sendMessageRequest.Message = xmlRequest.DocumentElement;

                var sendMessageResponse = kktServiceClient.SendMessageAsync(sendMessageRequest.Message)
                    .GetAwaiter()
                    .GetResult();

                var messageId = sendMessageResponse.MessageId;

                _logWriter.Trace($"messageId: {messageId}");


                var stopwatch = Stopwatch.StartNew();

                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds > ResponseTimeout)
                    {
                        stopwatch.Stop();
                        throw new TimeoutException("Превышено время ожидания ответа.");
                    }
                    
                    Thread.Sleep(ResponseWaitTime);
                    var getMessageRequest = new KktService.GetMessageRequest {MessageId = messageId};

                    try
                    {
                        var getMessageResponse =
                            kktServiceClient.GetMessageAsync(getMessageRequest)
                                .GetAwaiter()
                                .GetResult();
                        
                        if (getMessageResponse.ProcessingStatus != KktService.ProcessingStatuses.COMPLETED) continue;

                        _logWriter.Trace(getMessageResponse.Message.OuterXml);

                        return getMessageResponse.Message.OuterXml;
                    }
                    catch (FaultException<KktService.AuthenticationFault> ex)
                    {

                        _logWriter.Error(ex);
                        throw;
                    }
                    catch (FaultException<KktService.MessageNotFoundFault> ex)
                    {
                        _logWriter.Error(ex);
                        throw;
                    }
                }
            }
        }
    }
}