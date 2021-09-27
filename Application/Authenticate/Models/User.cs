using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authenticate.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
