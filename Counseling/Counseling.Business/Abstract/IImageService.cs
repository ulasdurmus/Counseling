using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Abstract
{
    public interface IImageService
    {
        Task<Image> GetImageByUserIdAsync(string userId);
        int CheckImageName(string imageName);
        Task CretaeAsync(Image image);
        Task<Image> GetByIdAsync(int id);
        Task<List<Image>> GetAllAsync();
        void Update(Image image);
        void Delete(Image image);
    }
}
