using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Abstract
{
    public interface ITherapistRepository : IGenericRepository<Therapist>
    {
        public List<Therapist> GetAllEntityAndUserInformation(List<Therapist> entitys, IList<User> users);
        public Task<List<University>> GetAllUniversty();
        public Task<List<Department>> GetAllDepartments();
        public Task<List<TherapistTitle>> GetAllTitles();
        public Task CreateTherapistWithFullDataAsync(Therapist therapist, int[] selectedCategories = null);
        public Task<Therapist> GetTherapistFullDataByUserName(string userName);
        public Task<List<Education>> GetEducationFullData();
        public Task UpdateTherapist(Therapist therapist, int[] selectedCategories);
        public Task<List<Certificate>> GetAllCertificates();
        public Task<int> GetTherapistIdByUserName(string userName);
    }
}
