using Counseling.Entity.Entity;
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
    }
}
