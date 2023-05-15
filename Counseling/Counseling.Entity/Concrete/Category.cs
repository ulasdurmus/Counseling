using Counseling.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class Category:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public List<TherapistCategory> TherapistCategories { get; set; }
    }
}
