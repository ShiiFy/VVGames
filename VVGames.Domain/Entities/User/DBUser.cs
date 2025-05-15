using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Enums;

namespace VVGames.Domain.Entities.User
{
    public class DBUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

        [Display(Name = "Name")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 charicters.")]
        public string PasswordHash { get; set; }

        [Display(Name = "Phone")]
        [StringLength(15, MinimumLength = 9)]
        public string PhoneNumber { get; set;}

        [Display(Name = "User Blocked")]
        public bool IsBlocked { get; set; } = false;

        public URole Level { get; set;}

        [DataType(DataType.Date)]
        public DateTime LoginDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastDateTime { get; set; }

    }
}
