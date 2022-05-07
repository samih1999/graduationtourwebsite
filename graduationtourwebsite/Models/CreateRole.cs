using System.ComponentModel.DataAnnotations;

namespace graduationtourwebsite.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
