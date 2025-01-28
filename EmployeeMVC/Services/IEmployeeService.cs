using EmployeeShared.Models;

namespace EmployeeMVC.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync(string SortColumn="", string SortOrder = "", int statusId=0 , int departmentId = 0);
        Task<Employee> GetEmployeeAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<List<Status>> GetAllStatusesAsync();
        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
