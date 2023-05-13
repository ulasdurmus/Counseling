using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Counseling.MVC.Models.ViewModels.ReservationModels
{
    public class ReservationPaymentviewModel
    {
        public int Id { get; set; }
        [DisplayName("Danışan Ad Soyad")]
        public string ClientFirstName { get; set; }
        [DisplayName("Danışan Soyad")]
        public string ClientLastName { get; set; }

        [DisplayName("Terapist Ad Soyad")]
        public string TherapistName { get; set; }

        [DisplayName("Fatura Adresi")]
        public string Address { get; set; }

        [DisplayName("Şehir")]
        public string City { get; set; }

        [DisplayName("Danışan Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string ClientPhoneNumber { get; set; }

        [DisplayName("Terapist Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string TherapistPhoneNumber { get; set; }

        [DisplayName("Danışan Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        public string ClientMail { get; set; }

        [DisplayName("Terapist Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        public string TherapistMail { get; set; }

        // Credit Card
        [DisplayName("Kart Sahibi Ad Soyad giriniz")]
        [Required(ErrorMessage ="Ad ve Soyad zorunludur.")]
        public string CardName { get; set; }

        [DisplayName("Kart numarası")]
        [Required(ErrorMessage = "Kart numarası zorunludur.")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "Ay bilgisi zorunludur")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "Yıl bilgisi zorunludur")]
        public string ExpirationYear { get; set; }

        [DisplayName("Cvc No")]
        [Required(ErrorMessage = "Cvc bilgisi zorunludur")]
        public string Cvc { get; set; }
        [DisplayName("Ücret")]
        public decimal? Price { get; set; }
        [DisplayName("Rezervasyon Tarihi")]
        public DateTime ReservationDate { get; set; }

    }
}
