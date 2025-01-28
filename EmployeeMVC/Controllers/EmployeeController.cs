using EmployeeShared.Models;
using EmployeeMVC.Models;
using EmployeeMVC.Services;
using EmployeeMVC.Enums;
using EmployeeMVC.Classes.Helpers;

using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeMVC.Controllers

{
    public class EmployeeController : Controller
    {

        private readonly EmployeeService _employeeService;
        private readonly GlobalSettingsService _globalSettingsService;

        public EmployeeController(EmployeeService employeeService, GlobalSettingsService globalSettingsService)
        {
            _employeeService = employeeService;
            _globalSettingsService = globalSettingsService; 
        }

        public async Task<IActionResult> Index(string sortColumn="EmployeeId", string sortOrder = "asc", int statusId = 0, int departmentId = 0, int pageNumber =  1)
        {
            if (!string.IsNullOrEmpty(sortColumn))
            {
                TempData[sortColumn + "_SortOrder"] = sortOrder;
            }

            var statuses = await _employeeService.GetAllStatusesAsync() ?? new List<Status>();
            var departments = await _employeeService.GetAllDepartmentsAsync() ?? new List<Department>();

            var helper = new EmployeeHelper();
            EmployeeListViewModel employeeViewModel = new EmployeeListViewModel();
            employeeViewModel.Departments = helper.GetListOfDepartments(departments);
            employeeViewModel.Statuses = helper.GetListOfStatuses(statuses);
            employeeViewModel.CurrentSortedColumn = sortColumn;
            employeeViewModel.CurrentSortOrder = sortOrder;
            employeeViewModel.CurrentPageNumber = pageNumber;
            employeeViewModel.SelectedStatusId = statusId;
            employeeViewModel.SelectedDepartmentId = departmentId;
            return View(employeeViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var statuses = await _employeeService.GetAllStatusesAsync();
            var departments = await _employeeService.GetAllDepartmentsAsync();

            // Filter statuses & departments so that Only "Active" ones are used going forward when creating a new Employee
            statuses = statuses.Where(s => s.IsActive == true).ToList();
            departments = departments.Where(s => s.IsActive == true).ToList();

            var helper = new EmployeeHelper();
            var viewModel = new CreateEditEmployeeViewModel
            {
                employee = new Employee(),
                statuses = helper.GetListOfStatuses(statuses),
                departments = helper.GetListOfDepartments(departments)
            };
            viewModel.employee.IsActive = true;
            viewModel.employee.DateOfBirth = DateTime.Now.AddYears(-20);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditEmployeeViewModel createEmployee)
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync() ?? new List<Employee>();
                // Check If Email Address Is Unique
                if (employees.Any(e => e.Email.Trim() == (createEmployee.employee.Email ?? "").Trim()))
                {
                    // Another way of implementing this unique email address is by applying the "UniqueEmail" attribute against the Email field in the Model 
                    //[UniqueEmail(ErrorMessage = "This email address is already taken.")]
                    ModelState.AddModelError("", "The Email Address entered is already in use. Please use another.");
                }

                // Check Employee Number uniqueness if new employee status is "Active"
                if (createEmployee.employee.IsActive == true)
                {
                    if (employees.Any(e => e.EmployeeNumber.Trim() == (createEmployee.employee.EmployeeNumber??"").Trim() && e.IsActive == true))
                    {
                        ModelState.AddModelError("", "The Employee Number entered is already in use against another active employee.");
                    }
                }

                if (ModelState.IsValid)
                {
                    
                    await _employeeService.AddEmployeeAsync(createEmployee.employee);
                    TempData[EmployeeAppEnums.Message.SuccessMessage.ToString()] = String.Format(" - Employee Created");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            var statuses = await _employeeService.GetAllStatusesAsync();
            var departments = await _employeeService.GetAllDepartmentsAsync();

            var helper = new EmployeeHelper();
            createEmployee.statuses = helper.GetListOfStatuses(statuses) ?? new List<SelectListItem>();
            createEmployee.departments = helper.GetListOfDepartments(departments) ?? new List<SelectListItem>();

            return View(createEmployee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            var statuses = await _employeeService.GetAllStatusesAsync();
            var departments = await _employeeService.GetAllDepartmentsAsync();

            // Need to set these otherwise ModelState will fail due to the tables being joined
            employee.Department = departments.Where(d => d.DepartmentID == employee.DepartmentID).FirstOrDefault();
            employee.Status = statuses.Where(d => d.StatusID == employee.StatusID).FirstOrDefault();

            var helper = new EmployeeHelper();
            var viewModel = new CreateEditEmployeeViewModel
            {
                employee = employee,
                statuses = helper.GetListOfStatuses(statuses),
                departments = helper.GetListOfDepartments(departments)
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateEditEmployeeViewModel updateEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData[EmployeeAppEnums.Message.SuccessMessage.ToString()] = String.Format(" - Employee Updated");
                    await _employeeService.UpdateEmployeeAsync(updateEmployee.employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            var statuses = await _employeeService.GetAllStatusesAsync();
            var departments = await _employeeService.GetAllDepartmentsAsync();

            var helper = new EmployeeHelper();
            updateEmployee.statuses = helper.GetListOfStatuses(statuses);
            updateEmployee.departments = helper.GetListOfDepartments(departments);

            return View(updateEmployee);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            var statuses = await _employeeService.GetAllStatusesAsync();
            var departments = await _employeeService.GetAllDepartmentsAsync();

            // Need to set these otherwise ModelState will fail due to the tables being joined
            employee.Department = departments.Where(d => d.DepartmentID == employee.DepartmentID).FirstOrDefault();
            employee.Status = statuses.Where(d => d.StatusID == employee.StatusID).FirstOrDefault();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);

            TempData[EmployeeAppEnums.Message.SuccessMessage.ToString()] = String.Format(" - Employee Deleted");

            return RedirectToAction(nameof(Index));
        }


        //[HttpPost]
        public async Task<ActionResult> GetEmployeePartial(string sortColumn = "EmployeeId", string sortOrder = "asc", int statusId=0, int departmentId = 0, int currPage = 1)
        {
            int totalResultsPerPage = _globalSettingsService.GetTotalResultsPerPage(); // Get the Rows Per Page Setting from AppSettings
            var employees = await _employeeService.GetAllEmployeesAsync(sortColumn, sortOrder, statusId, departmentId);

            EmployeeListViewModel employeeViewModel = new EmployeeListViewModel();
            employeeViewModel.Employees = employees.ToPagedList(currPage, totalResultsPerPage);
            employeeViewModel.CurrentSortedColumn = sortColumn;
            employeeViewModel.CurrentSortOrder = sortOrder;
            employeeViewModel.SelectedStatusId = statusId;
            employeeViewModel.SelectedDepartmentId = departmentId;

            return PartialView("_EmployeeList", employeeViewModel);
        }

    }
}