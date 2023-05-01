using Counseling.Business.Abstract;
using Counseling.Data.Abstract;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Concrete
{
    public class TherapistManager : ITherapistService
    {
        private ITherapistRepository _therapistRepository;
        public TherapistManager(ITherapistRepository therapistRepository)
        {
            _therapistRepository = therapistRepository;
        }

        public async Task CreateAsync(Therapist therapist)
        {
            await _therapistRepository.CreateAsync(therapist);
        }

        public async Task CreateTherapistWithFullDataAsync(Therapist therapist, int[] selectedCategories = null)
        {
            await _therapistRepository.CreateTherapistWithFullDataAsync(therapist, selectedCategories);
        }

        public void Delete(Therapist therapist)
        {
            _therapistRepository.Delete(therapist);
        }

        public async Task<List<Therapist>> GetAllAsync()
        {
            return await _therapistRepository.GetAllAsync();
        }

        public Task<List<Certificate>> GetAllCertificates()
        {
            return _therapistRepository.GetAllCertificates();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _therapistRepository.GetAllDepartments();
        }

        public List<Therapist> GetAllEntityAndUserInformation(List<Therapist> entitys, IList<User> users)
        {
            return _therapistRepository.GetAllEntityAndUserInformation(entitys, users);
        }

        public async Task<List<TherapistTitle>> GetAllTitles()
        {
            return await _therapistRepository.GetAllTitles();
        }

        public Task<List<University>> GetAllUniversty()
        {
            return _therapistRepository.GetAllUniversty();
        }

        public async Task<Therapist> GetByIdAsync(int id)
        {
            return await _therapistRepository.GetByIdAsync(id);
        }

        public async Task<List<Education>> GetEducationFullData()
        {
            return await _therapistRepository.GetEducationFullData();
        }

        public async Task<Therapist> GetTherapistFullDataByUserName(string userName)
        {
            return await _therapistRepository.GetTherapistFullDataByUserName(userName);
        }

        public void Update(Therapist therapist)
        {
            _therapistRepository.Update(therapist);
        }

        public async Task UpdateTherapist(Therapist therapist, int[] selectedCategories)
        {
            await _therapistRepository.UpdateTherapist(therapist, selectedCategories);
        }
    }
}
