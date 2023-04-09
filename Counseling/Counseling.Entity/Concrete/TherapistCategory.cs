using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class TherapistCategory
    {
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
