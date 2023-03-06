using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string roleName { get; set; }
    }
}
