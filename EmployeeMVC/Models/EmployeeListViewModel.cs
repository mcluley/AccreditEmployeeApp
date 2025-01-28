using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using EmployeeShared.Models;

namespace EmployeeMVC.Models
{
        public class EmployeeListViewModel
        {
            public IPagedList<Employee> Employees { get; set; }
            public List<SelectListItem> Statuses { get; set; }
            public List<SelectListItem> Departments { get; set; }
            public string CurrentSortedColumn { get; set; }
            public string CurrentSortOrder { get; set; }

            public int CurrentPageNumber { get; set; }

           public int? SelectedStatusId { get; set; }
           public int? SelectedDepartmentId { get; set; }
    }
}
