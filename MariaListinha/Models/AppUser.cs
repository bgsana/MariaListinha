using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MariaListinha.Models
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [StringLength(300)]
        public string ProfilePicture { get; set; }
    }
}