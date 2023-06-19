using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class GetUser
    {
        public int UserID { get; set; }
        public int Role_Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email_id { get; set; }

    }
}
