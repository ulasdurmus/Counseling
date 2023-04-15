using Counseling.Entity.Abstract;
using Counseling.Entity.Entity.Identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class Therapist : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User  { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public bool IsOnline { get; set; }
        public List<TherapistCategory> TherapistCategories { get; set; }
        public List<ClientTherapist> ClientTherapists { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<Education> Educations { get; set; }
        public int TitleId{ get; set; }
    }
}
