using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using EmployeeShared.Models;

namespace EmployeeMVC.Models
{
        public class CreateEditEmployeeViewModel
    {
            public Employee employee { get; set; }
            public List<SelectListItem> statuses { get; set; }
            public List<SelectListItem> departments { get; set; }
    }
}
