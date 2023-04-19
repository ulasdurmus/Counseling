using Counseling.Entity.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Counseling.MVC.Areas.Admin.Models.ViewModels
{
    public class TherapistAddViewModel
    {
        //User
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad boş bırakılmamalıdır.")]
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılmamalıdır.")]
        public string UserName { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir boş bırakılmamalıdır.")]
        public string Address { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet boş bırakılmamalıdır.")]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }

        [DisplayName("Profil Foroğrafı")]
        [Required(ErrorMessage = "Profil Fotoğrafı boş bırakılmamalıdır.")]
        public IFormFile ProfilePic { get; set; }

        [DisplayName("Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail boş bırakılmamalıdır.")]
        public string Email { get; set; }

        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon Numarası boş bırakılmamalıdır.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //Therapist
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public List<SelectListItem> GenderList { get; set; }
    }
}
