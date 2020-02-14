using Newtonsoft.Json;

namespace FnsOpenApi.Domain.Models.ReceiptResponse
{
    public class ReceiptItem
    {
        [JsonProperty("sum")]
        public long Sum { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ndsCalculated10")]
        public long NdsCalculated10 { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }
    }
}