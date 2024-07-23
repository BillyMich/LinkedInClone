using Newtonsoft.Json;

namespace LinkedInWebApi.Core.Extensions
{
    public static class JsonSerialazationExtension
    {
        public static string SerializeToJson<T>(this List<T> entitys)
        {
            return JsonConvert.SerializeObject(entitys);
        }

    }
}
