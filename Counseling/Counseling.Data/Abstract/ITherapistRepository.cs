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
    }
}
