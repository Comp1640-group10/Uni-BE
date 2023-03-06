using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uni_BackEnd_API.Models
{
    public class Topic
    {
        [Key]
        public  int id { get; set; }
        [Required]
        public string topicName { get; set; }
        [Required]
        public DateTime closureDate { get; set; }
        [Required]
        public DateTime finalClosureDate { get; set; }
    }
}
