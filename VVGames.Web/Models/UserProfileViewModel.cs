using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VVGames.Web.Models
{
    public class UserProfileViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}