using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Core
{
    public class Jobs
    {
        public static string UploadImage(IFormFile image, string folderName,int ImageNameRepeatCount)
        {
            var extension = Path.GetExtension(image.FileName);
            var nameWithoutExtension = Path.GetFileNameWithoutExtension(image.FileName);
            string fileName = image.FileName;
            
            if (ImageNameRepeatCount > 0)
            {
                nameWithoutExtension = nameWithoutExtension.Replace($"({ImageNameRepeatCount - 1})", string.Empty);
                fileName = $"{nameWithoutExtension}({ImageNameRepeatCount}){extension}";
            }
            
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{folderName}", fileName);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return fileName;
        }
    }
}
