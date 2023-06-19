using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class UserModel
    {       
        public int UserID { get; set; }
        [Required (ErrorMessage = "{0} Select Doctor or Patient")]
        public int Role_Id { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty ")]
        public string Email_id { get; set; }
   
    }
}
