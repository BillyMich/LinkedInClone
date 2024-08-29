using System.Xml.Serialization;

namespace LinkedInWebApi.Core.Extensions
{
    public static class XMLSerialazationExtension
    {
        public static string SerializeToXml<T>(this List<T> entitys)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, entitys);
                return textWriter.ToString();
            }
        }
    }
}
