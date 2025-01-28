using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee ID")]
        public int EmployeeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9 \.\&\'\-]+)$", ErrorMessage = "{0} must be numbers only")]
        [StringLength(10, ErrorMessage = "{0} cannot be longer than 10 characters.")]
        [DisplayName("Employee Number")]
        public string EmployeeNumber { get; set; } = "";

        [Required]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "{0} must be characters only")]
        [StringLength(30, ErrorMessage = "{0} cannot be longer than 30 characters.")]
        [DisplayName("First Name")]
        public string Firstname { get; set; } = "";

        [Required]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "{0} must be characters only")]
        [StringLength(30, ErrorMessage = "{0} cannot be longer than 30 characters.")]
        [DisplayName("Last Name")]
        public string Lastname { get; set; } = "";

        [Required]
        [RegularExpression(@"^([a - zA - Z0 - 9._ % -]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$", ErrorMessage = "{0} must be a valid email address")]
        [StringLength(100, ErrorMessage = "{0} cannot be longer than 100 characters.")]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date Only")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [DisplayName("DOB")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public Status Status { get; set; } = new Status();
        public Department Department { get; set; } = new Department();
    }

}
