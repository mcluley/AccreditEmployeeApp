using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeAPI.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
