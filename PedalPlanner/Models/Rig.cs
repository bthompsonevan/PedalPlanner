using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedalPlanner.Models
{
    public class Rig
    {
        public int RigID { get; set; }
        public string Instrument { get; set; }
        public int BoardSize { get; set; }
        public string CreatedBy { get; set; }
       
        

    }
}
