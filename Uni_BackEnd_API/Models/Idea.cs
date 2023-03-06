using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class Idea
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public string filePath { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        [Required]
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; }
        [Required]
        public int topicId { get; set; }
        [ForeignKey("topicId")]
        public Topic topic { get; set; }
        public IEnumerable<Comment> comment{ get; set; }
        public IEnumerable<View> view { get; set; }
        public IEnumerable<React> reacts{ get; set; }
    }
}
