using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedalPlanner.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public ICollection<Rig> Rigs { get; set; }
        [PersonalData]
        public ICollection<Pedal> Pedals { get; set; }
    }
}
