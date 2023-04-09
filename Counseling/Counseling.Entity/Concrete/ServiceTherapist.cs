using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class ServiceTherapist
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }
    }
}
