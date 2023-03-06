using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class Category
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }
        [Required]
        public string categoryName { get; set; }

    }
}
