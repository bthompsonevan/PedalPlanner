using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedalPlanner.Models
{
    public class Rig
    {
        public int RigID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string Instrument { get; set; }
        [Required]
        [Range(1, 30, ErrorMessage = "Pedalboard size must be greater than one and less than 30")]
        public int BoardSize { get; set; }          
        public string CreatedBy { get; set; }
       
        

    }
}
