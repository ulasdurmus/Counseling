using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class ClientTherapist
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }
    }
}
