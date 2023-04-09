using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Entity.Entity.Identitiy
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
