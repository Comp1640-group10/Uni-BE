using System.ComponentModel.DataAnnotations;

namespace Uni_BackEnd_API.Models
{
    public class LoginModel
    {
        [Required]
        public string fullName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
