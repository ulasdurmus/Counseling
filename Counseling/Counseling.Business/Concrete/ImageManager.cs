using Counseling.Business.Abstract;
using Counseling.Data.Abstract;
using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public int CheckImageName(string imageName)
        {
            return _imageRepository.CheckImageName(imageName);
        }

        public async Task CretaeAsync(Image image)
        {
            await _imageRepository.CreateAsync(image);
        }

        public void Delete(Image image)
        {
            _imageRepository.Delete(image);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _imageRepository.GetAllAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id);
        }

        public void Update(Image image)
        {
            _imageRepository.Update(image);
        }
    }
}
