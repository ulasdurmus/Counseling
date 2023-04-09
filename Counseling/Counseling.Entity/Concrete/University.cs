using Counseling.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class University : INameIdEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
