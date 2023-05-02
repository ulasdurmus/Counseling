using Counseling.Entity.Entity;

namespace Counseling.MVC.Models.ViewModels.ServiceModels
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public int TherapistId { get; set; }
        //public Therapist Therapist { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public ServiceTherapist ServiceTherapist { get; set; }
        public List<ServiceCategory> ServiceCategories { get; set; }
    }
}
