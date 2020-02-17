using System.Xml.Serialization;

namespace FnsOpenApi.Client.Response
{
    [XmlRoot(ElementName = "GetTicketResponse", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
    public class GetTicketResponse
    {
        [XmlElement(ElementName = "Result", Namespace = "urn://x-artefacts-gnivc-ru/ais3/kkt/KktTicketService/types/1.0")]
        public GetTicketResponseResult Result { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        
        public string SoapEnv { get; set; }
        [XmlAttribute(AttributeName = "ns", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns { get; set; }

        [XmlAttribute(AttributeName = "tns", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tns { get; set; }
    }
}