using Newtonsoft.Json;

namespace FnsOpenApi.Client.Models.ReceiptResponse
{
    public class Id
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }
}