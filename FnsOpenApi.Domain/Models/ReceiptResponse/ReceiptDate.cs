using Newtonsoft.Json;

namespace FnsOpenApi.Domain.Models.ReceiptResponse
{
    public class ReceiptDate
    {
        [JsonProperty("$date")]
        public long Date { get; set; }
    }
}