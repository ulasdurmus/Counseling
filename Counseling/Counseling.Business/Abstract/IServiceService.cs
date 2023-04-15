using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Abstract
{
    public interface IServiceService
    {
        Task CretaeAsync(Service service);
        Task<Service> GetByIdAsync(int id);
        Task<List<Service>> GetAllAsync();
        void Update(Service service);
        void Delete(Service service);
        Task<List<Service>> GetAllServiceWithFullDataAsync(bool isAproved);
    }
}
