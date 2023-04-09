using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Abstract
{
    public interface INameIdEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
