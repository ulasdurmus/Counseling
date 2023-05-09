using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public int TherapistId{ get; set; }
        public DateTime ReservationDate { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsPaid { get; set; }
        public List<ClientTherapist> ClientTherapists { get; set; }
        public List<ClientService> ClientServices { get; set; }
    }
}
