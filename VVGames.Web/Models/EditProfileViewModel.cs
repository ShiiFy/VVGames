using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VVGames.Web.Models
{
    public class EditProfileViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}