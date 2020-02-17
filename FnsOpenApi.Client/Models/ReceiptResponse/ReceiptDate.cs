using Newtonsoft.Json;

namespace FnsOpenApi.Client.Models.ReceiptResponse
{
    public class ReceiptDate
    {
        [JsonProperty("$date")]
        public long Date { get; set; }
    }
}