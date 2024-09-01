using System.Xml.Linq;
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

        public static async Task<string> GenerateUserXmlAsync(List<UserDto> users)
        {
            XElement usersElement = new XElement("Users",
                new List<XElement>(
                    users.ConvertAll(user =>
                        new XElement("User",
                            new XElement("Name", user.Name),
                            new XElement("Email", user.Email),
                            new XElement("Role", user.Role)
                        )
                    )
                )
            );

            XDocument document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), usersElement);
            using (StringWriter stringWriter = new StringWriter())
            {
                await Task.Run(() => document.Save(stringWriter));
                return stringWriter.ToString();
            }
        }
    }
}