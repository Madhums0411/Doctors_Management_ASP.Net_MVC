using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class DoctorModel
    {
        public int UserID { get; set; }
        public int Doctor_id { get; set; }
        public string Profile { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public int Age { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Job_specification { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public int Experience_year { get; set;}
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public long Contact_number { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public int Doctor_fee { get; set;}
        public int Trash { get; set;}
    }
}
