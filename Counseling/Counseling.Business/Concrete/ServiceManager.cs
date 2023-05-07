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
    public class ServiceManager : IServiceService
    {
        private IServiceRepository _serviceRepository;
        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task CreateServiceWithFullData(Service service, int[] selectedCategories = null)
        {
            await _serviceRepository.CreateServiceWithFullData(service, selectedCategories);
        }

        public async Task CretaeAsync(Service service)
        {
            await _serviceRepository.CreateAsync(service);
        }

        public void Delete(Service service)
        {
            _serviceRepository.Delete(service);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _serviceRepository.GetAllAsync();
        }

        public async Task<List<Service>> GetAllServiceWithFullDataAsync(bool isAproved)
        {
            return await _serviceRepository.GetAllServiceWithFullDataAsync(isAproved);
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public async Task<List<Service>> GetServicesWithFullDataByTherapistIdAsync(int therapistId)
        {
            return await _serviceRepository.GetServicesWithFullDataByTherapistIdAsync(therapistId);
        }

        public async Task<Service> GetServiceWithFullDataById(int id)
        {
            return await _serviceRepository.GetServiceWithFullDataById(id);
        }

        public void Update(Service service)
        {
            _serviceRepository.Update(service);
        }
    }
}
