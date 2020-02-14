using System.Xml.Serialization;

namespace FnsOpenApi.Domain.Response
{
    [XmlRoot(ElementName = "Result", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
    public class GetTicketResponseResult
    {
        [XmlElement(ElementName = "Code", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
        public string Code { get; set; }

        [XmlElement(ElementName = "Ticket", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
        public string Ticket { get; set; }
    }
}