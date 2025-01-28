using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeShared.Models
{
    public class Department
    {
        [Key]
        [DisplayName("Department ID")]
        public int DepartmentID { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "{0} must be numbers only")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters.")]
        [DisplayName("Department Description")]
        public string DepartmentDescription { get; set; } = "";

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
