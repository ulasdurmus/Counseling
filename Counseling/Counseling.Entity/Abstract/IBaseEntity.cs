using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Abstract
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }

    }
}
