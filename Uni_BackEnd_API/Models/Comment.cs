using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        [Required]
        public int ideaId { get; set; }
        [ForeignKey("ideaId")]
        public Idea idea { get; set; }
    }
}
