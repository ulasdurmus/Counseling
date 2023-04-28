using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class Education
    {
        public int Id { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public University University { get; set; }
        public int? UniversityId{ get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

    }
}
