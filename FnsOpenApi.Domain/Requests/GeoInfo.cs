using System.Xml.Serialization;

namespace FnsOpenApi.Domain.Requests
{
    [XmlRoot("GeoInfo")]
    public class GeoInfo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}