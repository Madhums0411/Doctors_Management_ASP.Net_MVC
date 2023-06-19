using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class LoginModel
    {
        [Required (ErrorMessage = "{0} Should not be Empty ")]
        public string Email_id { get; set; }
        [Required (ErrorMessage ="{0} Should not be Empty ")]
        public string Password { get; set; }


    }
}
