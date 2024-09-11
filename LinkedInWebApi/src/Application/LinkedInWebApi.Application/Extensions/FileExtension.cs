using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;

namespace LinkedInWebApi.Application.Extensions
{
    public static class FileExtension
    {
        public static byte[] ConvertToByteArray(this IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static FileDto ConvertToFileDto(this IFormFile file)
        {
            return new FileDto
            {
                FileName = file.FileName,
                FileType = file.ContentType,
                DataOfFile = file.ConvertToByteArray()
            };
        }

    }
}
