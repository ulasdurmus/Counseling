using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Counseling.MVC.Areas.Admin.Models.ViewModels
{
    public class AdminUpdateViewModel
    {
        public string UserId { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılmamalıdır.")]
        public string UserName { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad boş bırakılmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail boş bırakılmamalıdır.")]
        public string Email { get; set; }

        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon Numarası boş bırakılmamalıdır.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet boş bırakılmamalıdır.")]
        public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi boş bırakılmamalıdır.")]
        public DateTime DateOfBirth { get; set; }

        
        public IFormFile ProfilePic { get; set; }
        public string ProfilPictureUrl { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
    }
}
