using System.Xml;
using System.Xml.Serialization;

namespace LinkedInWebApi.Core.Extensions
{
    public static class XMLSerialazationExtension
    {

        public static string SerializeToXml<T>(List<T> obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                xmlSerializer.Serialize(xmlWriter, obj, namespaces);
                return stringWriter.ToString();
            }
        }
    }
}