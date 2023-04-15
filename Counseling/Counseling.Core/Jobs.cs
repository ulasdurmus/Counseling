using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Core
{
    public class Jobs
    {
        public static string UploadImage(IFormFile image, string folderName)
        {
            var extension = Path.GetExtension(image.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{folderName}", extension);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return extension;
        }
    }
}
