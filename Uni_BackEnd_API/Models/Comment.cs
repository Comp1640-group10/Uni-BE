using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class Comment
    {
        [Key]
        public string id { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
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
