using Counseling.Entity.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Counseling.MVC.Models.ViewModels.AccountModels
{
    public class ClientManageViewModel
    {
        public string UserId { get; set; }
        public int ClientId { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur")]
        public string UserName { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet boş bırakılmamalıdır.")]
        public string Gender { get; set; }
        [DisplayName("Adres")]
        public string Address { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Profil Foroğrafını Güncelle")]
        public IFormFile ProfilePic { get; set; }
        public string ProfilPictureUrl { get; set; }
        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
