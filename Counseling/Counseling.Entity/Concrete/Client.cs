using Counseling.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class Client : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public List<ClientTherapist> ClientTherapists { get; set; }
        public List<ClientService> ClientServices { get; set; }

    }
}
