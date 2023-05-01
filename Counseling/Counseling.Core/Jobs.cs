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
        public static string GetUrl(string text)
        {                       
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
                     
            text = text.ToLower();
                    
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");

            text = text.Replace(".", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("`", "");
            text = text.Replace("\"", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("?", "");
            text = text.Replace(",", "");
            text = text.Replace("-", "");
            text = text.Replace("_", "");
            text = text.Replace("$", "");
            text = text.Replace("&", "");
            text = text.Replace("%", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("+", "");
            text = text.Replace("!", "");
            text = text.Replace("=", "");
            text = text.Replace(";", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("|", "");
            text = text.Replace("*", "");

            text = text.Replace(" ", "-");

            return text;
        }
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
        public static string UploadPdf(IFormFile document)
        {
            var extension = Path.GetExtension(document.FileName);
            var randomName = $"{Guid.NewGuid()}{extension}";
            //Şimdi de resmi sunucuya yüklüyoruz
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/pdfs", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                document.CopyTo(stream);
            }

            return randomName;
        }

    }
}
