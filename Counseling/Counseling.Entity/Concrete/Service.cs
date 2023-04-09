﻿using Counseling.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity
{
    public class Service:IBaseEntity
    {
        public int Id { get; set; }
        public int  TherapistId { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public decimal? Price { get; set; }
        public bool IsConfirmed { get; set; }// eğer randevu onaylanırsa bu kontrolden sonra ödemeye geçilecek
        public ServiceTherapist ServiceTherapist { get; set; }
        public List<ServiceCategory> ServiceCategories{ get; set; }
        //Terapist- Randevu listesi 
    }
}
