using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Abstract
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        void Update(Category category);
        void Delete(Category category);

    }
}
