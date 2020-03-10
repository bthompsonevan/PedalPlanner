using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedalPlanner.Models
{
    public class ExtraIdentityProperties : IdentityUser
    {
        
        public ICollection<Rig> Rigs { get; set; }
    }
}
