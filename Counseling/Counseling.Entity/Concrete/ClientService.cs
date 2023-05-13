using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class ClientService
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int ReservationId { get; set; }


    }
}
