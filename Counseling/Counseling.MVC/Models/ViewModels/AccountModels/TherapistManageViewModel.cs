using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Counseling.Entity.Entity;

namespace Counseling.MVC.Models.ViewModels.AccountModels
{
    public class TherapistManageViewModel
    {
        public string UserId { get; set; }
        public int TherapistId { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        public string LastName { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        public string Description { get; set; }

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
        public int[] SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }

        [DisplayName("Universite")]
        public int? UniversityId { get; set; }
        public List<University> Universities { get; set; }
        [DisplayName("Bölüm bilgisi")]
        public int? DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        [DisplayName("Ünvan bilgisi")]
        public int? TitleId { get; set; }
        public List<TherapistTitle> Titles { get; set; }
        public IFormFile CertificatePdf { get; set; }
        public List<Certificate> Certificates { get; set; }
        [DisplayName("Sertifika Adı")]
        public string CertificateName { get; set; }
        [DisplayName("Sertifika Açıklaması")]
        public string CertificateDescription { get; set; }
    }
}
