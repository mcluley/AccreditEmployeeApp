using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeMVC.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StatusID { get; set; }
        public int DepartmentID { get; set; }

        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }

}
