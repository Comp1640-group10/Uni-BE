using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Uni_BackEnd_API.Models
{
    public class NewUserModel
    {
        public string fullName { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public int? departmentId { get; set; }
    }
}
