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
        [Required]
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        [Required]
        public string categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; }
        [Required]
        public string topicId { get; set; }
        [ForeignKey("topicId")]
        public Topic topic { get; set; }
    }
}
