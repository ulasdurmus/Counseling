using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Counseling.Entity.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Counseling.MVC.Models.ViewModels.AccountModels
{
    public class RegisterViewModel
    {
        public int RoleId { get; set; }
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

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır!")]
        public string RePassword { get; set; }
        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet boş bırakılmamalıdır.")]
        public string Gender { get; set; }
        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi boş bırakılmamalıdır.")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Profil Foroğrafı")]
        public IFormFile ProfilePic { get; set; }
        public int[] SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
        [DisplayName("Universite")]
        public int? UniversityId { get; set; }
        public List<University> Universities { get; set; }
        [DisplayName("Bölüm bilgisi")]
        public int? DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        [DisplayName("Ünvan bilgisi")]
        public int? TitleId { get; set; }
        public List<TherapistTitle> Titles { get; set; }
    }
}
