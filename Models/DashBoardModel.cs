using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEAffiliate.Models
{
    public class DashBoardModel
    {
       
        public int Commission { get; set; }
        public int Traffic { get; set; }
        public int Sales { get; set; }
        public int Settled { get; set; }
        public List<string> Date { get; set; }
        public List<string> LeadsData { get; set; }
        public List<string> ConversionData { get; set; }
        public List<string>LabelData { get; set; }
    }
    
}