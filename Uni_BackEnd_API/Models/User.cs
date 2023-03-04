using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{

    [Index(nameof(fullName), IsUnique = true)]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int roleId { get; set; }
        [ForeignKey("roleId")]
        public Role Role { get; set; }
        [Required]
        public string departmentId { get; set; }
        [ForeignKey("departmentId")]
        public Department Department { get; set; }
    }
}
