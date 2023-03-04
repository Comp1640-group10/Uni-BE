using System.ComponentModel.DataAnnotations;

namespace Uni_BackEnd_API.Models
{
    public class Department
    {
        [Key] 
        public int id { get; set; }
        [Required]
        public string departmentName { get; set; }
    }
}
