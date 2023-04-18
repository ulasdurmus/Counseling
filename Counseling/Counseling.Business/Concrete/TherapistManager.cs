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

        public void Delete(Therapist therapist)
        {
            _therapistRepository.Delete(therapist);
        }

        public async Task<List<Therapist>> GetAllAsync()
        {
            return await _therapistRepository.GetAllAsync();
        }

        public List<Therapist> GetAllEntityAndUserInformation(List<Therapist> entitys, IList<User> users)
        {
            return _therapistRepository.GetAllEntityAndUserInformation(entitys, users);
        }

        public async Task<Therapist> GetByIdAsync(int id)
        {
            return await _therapistRepository.GetByIdAsync(id);
        }

        public void Update(Therapist therapist)
        {
            _therapistRepository.Update(therapist);
        }
    }
}
