using System.Xml.Serialization;
using FnsOpenApi.Domain.Interfaces;

namespace FnsOpenApi.Domain.Requests
{
    [XmlRoot("GetTicketRequest", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
    public class GetTicketRequest  : IOpenApiClientRequest  
    {
        public GetTicketInfo GetTicketInfo { get; set; }
        public GeoInfo GeoInfo { get; set; }
    }
}