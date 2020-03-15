using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedalPlanner.Models
{
    public class Pedal
    {
        public int PedalID { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Pedal Name must be at least one charater, but less than 30")]
        public string PedalName { get; set; }
        [Required]
        public string PedalType { get; set; }  //  Example: Distortion Pedal
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Pedal Sub Type must be at least one charater, but less than 30")]
        public string PedalSubType { get; set; }  // Example: Fuzz
        [Required]
        public string PedalColor { get; set; }  // Example:  Distortion is orange - base off of line6 color scheme
        public string CreatedBy { get; set; }

        
        

    }
}
