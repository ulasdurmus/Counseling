using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;

namespace Counseling.MVC.Areas.Admin.Models.ViewModels
{
    public class ClientUserViewModel
    {
        // User 
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NormalizedName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public Image Image { get; set; }

        //Client
        public int ClientId { get; set; }
        public User User { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        //public List<ClientTherapist> ClientTherapists { get; set; }
        //public List<ClientService> ClientServices { get; set; }
    }
}
