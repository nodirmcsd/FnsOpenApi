using System.Xml.Serialization;

namespace FnsOpenApi.Client.Requests
{
    [XmlRoot("CheckTicketInfo")]
    public class CheckTicketInfo
    {
        public int Sum { get; set; }
        public string Date { get; set; }
        public string Fn { get; set; }
        public int TypeOperation { get; set; } = 1;
        public string FiscalDocumentId { get; set; }
        public string FiscalSign { get; set; }

    }
}