using Counseling.Data.Abstract;
using Counseling.Data.Concrete.Context;
using Counseling.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.EfCoreRepositories
{
    public class EfCoreServiceRepository : EfCoreGenericrepository<Service>, IServiceRepository
    {
        public EfCoreServiceRepository(CounselingContext _appContext) : base(_appContext)
        {
        }
        CounselingContext AppContext
        {
            get { return _dbContext as CounselingContext; }
        }

        public async Task<List<Service>> GetAllServiceWithFullDataAsync(bool isAproved)
        {
            var services = await  AppContext
                .Services
                .Where(s => s.IsApproved == isAproved)
                .Include(s => s.ServiceCategories)
                .ThenInclude(sc => sc.Category)
                .Include(s => s.ServiceTherapist)
                .ThenInclude(st => st.Therapist)
                .ToListAsync();
            return services;
        }
        public async Task<List<Service>> GetServicesWithFullDataByTherapistIdAsync(int therapistId)
        {
            var services = await AppContext
                .Services
                .Where(s => s.TherapistId == therapistId)
                .Include(s => s.ServiceCategories)
                .ThenInclude(sc => sc.Category)
                .Include(s => s.ServiceTherapist)
                .ThenInclude(st => st.Therapist)
                .ToListAsync();
            return services;
        }
    }
}
