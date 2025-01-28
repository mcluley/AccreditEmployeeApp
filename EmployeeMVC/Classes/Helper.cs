using EmployeeShared.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeMVC.Classes.Helpers;
public class EmployeeHelper
{
    public List<SelectListItem> GetListOfStatuses(List<Status> statuses)
    {
        var statusList = new List<SelectListItem>();
        SelectListItem sli = new SelectListItem();
        sli.Text = "Select ...";
        sli.Value = "0";
        statusList.Add(sli);

        foreach (Status stat in statuses)
        {
            sli = new SelectListItem();
            sli.Text = stat.StatusDescription;
            sli.Value = stat.StatusID.ToString();
            statusList.Add(sli);
        }

        return statusList;

    }

    public List<SelectListItem> GetListOfDepartments(List<Department> departments)
    {
        var deptList = new List<SelectListItem>();
        SelectListItem sli = new SelectListItem();
        sli.Text = "Select ...";
        sli.Value = "0";
        deptList.Add(sli);

        foreach (Department dept in departments)
        {
            sli = new SelectListItem();
            sli.Text = dept.DepartmentDescription;
            sli.Value = dept.DepartmentID.ToString();
            deptList.Add(sli);
        }

        return deptList;
    }
}
