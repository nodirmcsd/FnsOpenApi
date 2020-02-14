using Newtonsoft.Json;

namespace FnsOpenApi.Domain.Models.ReceiptResponse
{
    public class Id
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }
}