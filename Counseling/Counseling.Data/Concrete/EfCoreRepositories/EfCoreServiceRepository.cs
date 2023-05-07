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
                .ThenInclude(tu=> tu.User)
                .ThenInclude(si=> si.Image)
                .Include(s => s.ServiceTherapist)
                .ThenInclude(st=>  st.Therapist)
                .ThenInclude(tt=> tt.Title)
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
        public async Task<Service> GetServiceWithFullDataById(int id)
        {
            Service service = await AppContext
                .Services
                .Where(s => s.Id == id)
                .Include(s => s.ServiceCategories)
                .ThenInclude(sc => sc.Category)
                .FirstOrDefaultAsync();
            return service;
        }
        public async Task CreateServiceWithFullData(Service service, int[] selectedCategories = null)
        {
            await AppContext.Services.AddAsync(service);
            await AppContext.SaveChangesAsync();
            List<ServiceCategory> serviceCategories = selectedCategories
                .Select(sc => new ServiceCategory
                {
                    CategoryId = sc,
                    ServiceId = service.Id
                }).ToList();
            await AppContext.ServiceCategories.AddRangeAsync(serviceCategories);
            await AppContext.SaveChangesAsync();
            ServiceTherapist serviceTherapist = new ServiceTherapist
            {
                ServiceId = service.Id,
                TherapistId = service.TherapistId
            };
            await AppContext.ServiceTherapists.AddAsync(serviceTherapist);
            await AppContext.SaveChangesAsync();
            
        }
    }
}
