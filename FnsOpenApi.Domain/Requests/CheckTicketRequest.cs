using System.Xml.Serialization;
using FnsOpenApi.Domain.Interfaces;

namespace FnsOpenApi.Domain.Requests
{
    [XmlRoot("CheckTicketRequest", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
    public class CheckTicketRequest : IOpenApiClientRequest
    {
        public CheckTicketInfo CheckTicketInfo { get; set; }
        public GeoInfo GeoInfo { get; set; }
    }
}