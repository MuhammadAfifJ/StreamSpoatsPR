using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Server.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfileImage { get; set; }
    }
}
