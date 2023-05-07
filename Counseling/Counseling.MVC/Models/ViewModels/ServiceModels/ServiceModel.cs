using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;

namespace Counseling.MVC.Models.ViewModels.ServiceModels
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public int TherapistId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime RezervationDate { get; set; }
        public Therapist Therapist { get; set; }
        public User User{ get; set; }
        public string ImageUrl { get; set; }
        public List<Category> Categories { get; set; }
        //public ServiceTherapist ServiceTherapist { get; set; }
        //public List<ServiceCategory> ServiceCategories { get; set; }
    }
}
