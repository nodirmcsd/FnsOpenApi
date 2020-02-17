using FnsOpenApi.Client.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FnsOpenApi.Client.Models.ReceiptResponse
{
    
    public class ReceiptDetails
    {
        [JsonProperty("_id")]
        public Id Id { get; set; }
        
        [JsonProperty("protocolVersion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ProtocolVersion { get; set; }

        [JsonProperty("subtype")]
        public string SubType { get; set; }

        [JsonProperty("protocolSubversion")]
        public long ProtocolSubVersion { get; set; }

        [JsonProperty("receiveDate")]
        public ReceiptDate ReceiveDate { get; set; }

        [JsonProperty("id")]
        public string ReceiptDetailsId { get; set; }

        [JsonProperty("v2ValidateErr")]
        public string V2ValidateErr { get; set; }

        [JsonProperty("fsId")]
        public string FsId { get; set; }

        [JsonProperty("documentId")]
        public long DocumentId { get; set; }

        [JsonProperty("content")]
        public ReceiptContent Content { get; set; }

        [JsonProperty("ofdId")]
        public string OfdId { get; set; }

        [JsonProperty("kktRegId")]
        public string KktRegId { get; set; }
    }
}