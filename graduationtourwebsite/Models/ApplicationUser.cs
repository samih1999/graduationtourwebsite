using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace graduationtourwebsite.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        public byte[] profilepicture { get; set; }


    }
}
