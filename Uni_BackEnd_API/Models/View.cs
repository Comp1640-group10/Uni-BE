using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class View
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime visitTime { get; set; }
        [Required]
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        [Required]
        public string ideaId { get; set; }
        [ForeignKey("ideaId")]
        public Idea idea { get; set; }
    }
}
