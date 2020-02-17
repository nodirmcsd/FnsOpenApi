using System.Collections.Generic;
using FnsOpenApi.Client.Utils;
using Newtonsoft.Json;

namespace FnsOpenApi.Client.Models.ReceiptResponse
{
    public class ReceiptContent
    {
        [JsonProperty("ndsCalculated10")]
        public long NdsCalculated10 { get; set; }

        [JsonProperty("machineNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MachineNumber { get; set; }

        [JsonProperty("fiscalDriveNumber")]
        public string FiscalDriveNumber { get; set; }

        [JsonProperty("shiftNumber")]
        public long ShiftNumber { get; set; }

        [JsonProperty("receiptCode")]
        public long ReceiptCode { get; set; }

        [JsonProperty("cashTotalSum")]
        public long CashTotalSum { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("totalSum")]
        public long TotalSum { get; set; }

        [JsonProperty("fiscalSign")]
        public long FiscalSign { get; set; }

        [JsonProperty("ecashTotalSum")]
        public long ECashTotalSum { get; set; }

        [JsonProperty("userInn")]
        public string UserInn { get; set; }

        [JsonProperty("taxationType")]
        public long TaxationType { get; set; }

        [JsonProperty("fiscalDocumentNumber")]
        public long FiscalDocumentNumber { get; set; }

        [JsonProperty("operationType")]
        public long OperationType { get; set; }

        [JsonProperty("rawData")]
        public string RawData { get; set; }

        [JsonProperty("items")]
        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();

        [JsonProperty("requestNumber")]
        public long RequestNumber { get; set; }

        [JsonProperty("kktRegId")]
        public string KktRegId { get; set; }

        [JsonProperty("dateTime")]
        public ReceiptDate DateTime { get; set; }
    }
}