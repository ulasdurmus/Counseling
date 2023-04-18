using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Abstract
{
    public interface ITherapistService
    {
        Task CreateAsync(Therapist therapist);
        Task<Therapist> GetByIdAsync(int id);
        Task<List<Therapist>> GetAllAsync();
        void Update(Therapist therapist);
        void Delete(Therapist therapist);
        public List<Therapist> GetAllEntityAndUserInformation(List<Therapist> entitys, IList<User> users);
    }
}
