using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Http;

namespace LinkedInWebApi.Application.Extensions
{
    /// <summary>
    /// Extension methods for working with files.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// Converts the given <see cref="IFormFile"/> to a byte array.
        /// </summary>
        /// <param name="file">The <see cref="IFormFile"/> to convert.</param>
        /// <returns>The byte array representation of the file.</returns>
        public static byte[] ConvertToByteArray(this IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Converts the given <see cref="IFormFile"/> to a <see cref="FileDto"/> object.
        /// </summary>
        /// <param name="file">The <see cref="IFormFile"/> to convert.</param>
        /// <returns>The converted <see cref="FileDto"/> object.</returns>
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
