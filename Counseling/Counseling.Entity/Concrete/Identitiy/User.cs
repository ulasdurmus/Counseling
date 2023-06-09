﻿using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity.Identitiy
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
        public Therapist Therapist { get; set; }
        public Client Client { get; set; }
    }
}
