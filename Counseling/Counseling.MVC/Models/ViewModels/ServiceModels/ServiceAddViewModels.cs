﻿using Counseling.Entity.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Counseling.MVC.Models.ViewModels.ServiceModels
{
    public class ServiceAddViewModels
    {
        public string Url { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama girilmek zorundadır.")]
        public string Description { get; set; }
        [DisplayName("Aktif Mi")]
        public bool IsApproved { get; set; }
        [DisplayName("Ücret")]
        [Required(ErrorMessage = "Ücret girilmek zorundadır.")]
        public decimal? Price { get; set; }
        public ServiceTherapist ServiceTherapist { get; set; }
        [DisplayName("Kategori Bilgisi")]
        [Required(ErrorMessage = "Kategori Seçilmek zorundadır.")]
        public int[] SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
