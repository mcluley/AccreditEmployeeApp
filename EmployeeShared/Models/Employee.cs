using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeShared.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee ID")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Number Required")]
        [RegularExpression(@"^([0-9 \.\&\'\-]+)$", ErrorMessage = "{0} Must Be Numbers Only")]
        [StringLength(10, ErrorMessage = "{0} Cannot Exceed 10 Characters.")]
        [DisplayName("Employee Number")]
        public string EmployeeNumber { get; set; } = "";

        [Required(ErrorMessage = "A First Name Is Required")]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "{0} Must Be Characters Only")]
        [StringLength(30, ErrorMessage = "{0} Cannot Exceed 30 Ccharacters.")]
        [DisplayName("First Name")]
        public string Firstname { get; set; } = "";

        [Required(ErrorMessage = "A Last Name Is Required")]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "{0} Must Be Characters Only")]
        [StringLength(30, ErrorMessage = "{0} Cannot Exceed 30 Ccharacters.")]
        [DisplayName("Last Name")]
        public string Lastname { get; set; } = "";

        [Required(ErrorMessage = "Email Address Is Required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "{0} Cannot Exceed 100 Characters.")]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "A Date Of Birth Is Required")]
        [DataType(DataType.Date, ErrorMessage = "Date Only")]
        [DisplayName("DOB")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "An Employee Status Is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "An Employee Status Is Required")]
        [DisplayName("Status")]
        public int StatusID { get; set; }

        [Required(ErrorMessage = "An Employee Department Is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "An Employee Department Is Required")]
        [DisplayName("Department")]
        public int DepartmentID { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public Status Status { get; set; } = new Status(); // Foreign Key for Status
        
        public Department Department { get; set; } = new Department(); // Foreign Key for Department
    }


    //public class EmployeeForList
    //{
    //    public Employee Employee { get; set; }
    //    public string StatusDesc { get; set; }
    //    public string DepartmentDesc  { get; set; }

    //    //public Status Status { get; set; } = new Status(); // Foreign Key for Status
    //    //public Department Department { get; set; } = new Department(); // Foreign Key for Department
    //}

}
