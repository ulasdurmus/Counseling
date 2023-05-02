using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Abstract
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<List<Service>> GetAllServiceWithFullDataAsync(bool isAproved);
        public Task<List<Service>> GetServicesWithFullDataByTherapistIdAsync(int therapistId);
    }
    
}
