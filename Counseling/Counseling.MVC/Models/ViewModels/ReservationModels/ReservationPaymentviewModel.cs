using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Counseling.MVC.Models.ViewModels.ReservationModels
{
    public class ReservationPaymentviewModel
    {


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

    }
}
