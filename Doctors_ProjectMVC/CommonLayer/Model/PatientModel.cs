using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class PatientModel
    {
        public int UserID { get; set; }
        public int Patient_id { get; set; }
        public string Profile { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public DateTime Date_of_birth { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Gender { get; set; }
        public string Blood_group { get; set; }
        public string Medical_history { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Phone_number { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Address { get; set; }
        public int Trash { get; set; }
    }
}
