using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Uni_BackEnd_API.Models
{
    public class newIdeaModel
    {
        public string name { get; set; }
        public string text { get; set; }
        public string? filePath { get; set; }
        public DateTime dateTime { get; set; }
        public int categoryId { get; set; }
        public int topicId { get; set; }
    }
}
