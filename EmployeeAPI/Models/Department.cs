using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeAPI.Models
{
    public class Department
    {
        [Key]
        [DisplayName("Department ID")]
        public int DepartmentID { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "{0} must be numbers only")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters.")]
        [DisplayName("Department Description")]
        public string DepartmentDescription { get; set; } = "";

        [Required]
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }

}