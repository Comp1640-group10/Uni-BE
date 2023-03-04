using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Uni_BackEnd_API.Models
{
    public enum ReactOption
    {
        LIKE = 1,
        DISLIKE = -1,
        NOREACT = 0
    }
    public class React
    {
        [Key]
        public int id { get; set; }
        [Required]
        public ReactOption react { get; set; }
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
