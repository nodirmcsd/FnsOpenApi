using System.Xml.Serialization;

namespace FnsOpenApi.Client.Requests
{
    [XmlRoot("GeoInfo")]
    public class GeoInfo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}