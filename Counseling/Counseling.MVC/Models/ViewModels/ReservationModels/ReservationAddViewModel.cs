﻿using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using System.ComponentModel.DataAnnotations;

namespace Counseling.MVC.Models.ViewModels.ReservationModels
{
    public class ReservationAddViewModel
    {
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        [Required(ErrorMessage ="Rezervasyon saati boş bırakılmamalıdır.")]
        [DataType(DataType.DateTime)]
        public DateOnly ReservationDate { get; set; }
        public decimal? Price { get; set; }
        public User User{ get; set; }
        public int ReservationHourId { get; set; }
        public List<ReservationHour> ReservationHours{ get; set; }
    }
}
