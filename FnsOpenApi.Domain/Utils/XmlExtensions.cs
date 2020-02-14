using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FnsOpenApi.Domain.Utils
{
    public static class XmlExtensions
    {
        public static string ToXmlString<T>(this T input)
        {
            var serializer = new XmlSerializer(input.GetType());
            string xml;
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, input);
                memoryStream.Position = 0;
                using (var sr = new StreamReader(memoryStream))
                {
                    xml = sr.ReadToEnd();
                }
            }
            return xml;
        }

        public static T FromXmlString<T>(this string input)
        {
            T result;
            var serializer = new XmlSerializer(typeof(T));
            using (var sr = new StringReader(input))
            {
                result = (T) serializer.Deserialize(sr);
                sr.Close();
            }

            return result;
        }

        public static XmlDocument ToXmlDocument<T>(this T obj)
        {
            var xmlStr = ToXmlString(obj);
            var xml = new XmlDocument();
            xml.LoadXml(xmlStr);
            return xml;
        }
    }
}