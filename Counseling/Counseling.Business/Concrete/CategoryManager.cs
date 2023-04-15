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
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.CreateAsync(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
