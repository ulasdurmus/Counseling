using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;

namespace Counseling.MVC.Models.ViewModels.ReservationModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public int TherapistId { get; set; }
        public DateTime ReservationDate { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsPaid { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string TherapistName { get; set; }
        public string  TherapistEmail { get; set; }
        public string TherapistPhoneNumber { get; set; }
        public string RoleName { get; set; }

        //public List<ClientTherapist> ClientTherapists { get; set; }
        //public List<ClientService> ClientServices { get; set; }
    }
}
