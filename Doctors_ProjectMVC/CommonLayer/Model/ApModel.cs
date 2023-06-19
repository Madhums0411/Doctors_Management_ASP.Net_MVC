using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class ApModel
    {
        public int Ap_id { get; set; }
        public int Patient_id { get; set; }
        public string P_Name { get; set; }
        public DateTime Ap_Date { get; set; }
        public TimeSpan TimeSlotStart { get; set; }
        public TimeSpan TimeSlotEnd { get; set; }
        public string Purpose { get; set; }
        public int Doctor_id { get; set; }
        public string D_Name { get; set; }  
    }
}
