using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;

namespace Counseling.MVC.Areas.Admin.Models.ViewModels
{
    public class TherapistUserViewModel
    {
        
        //User
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public Image Image { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //Therapist
        public int TherapistId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public bool IsOnline { get; set; }
        public List<TherapistCategory> TherapistCategories { get; set; }
        public List<ClientTherapist> ClientTherapists { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<Education> Educations { get; set; }
        public int TitleId { get; set; }
    }
}
