using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedalPlanner.Models
{
    public class Pedal
    {
        public int PedalID { get; set; }
        public string PedalName { get; set; }
        public string PedalType { get; set; }  //  Example: Distortion Pedal
        public string PedalSubType { get; set; }  // Example: Fuzz
        public string PedalColor { get; set; }  // Example:  Distortion is orange - base off of line6 color scheme

        public ICollection<Rig> Rigs { get; set; }
        public IdentityUser identityUser { get; set; }

    }
}
