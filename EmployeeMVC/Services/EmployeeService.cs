using EmployeeShared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace EmployeeMVC.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(string sortColumn="", string sortOrder = "asc", int statusId = 0, int departmentId = 0)
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>($"api/employees?sortColumn={sortColumn}&sortOrder={sortOrder}&statusId={statusId}&departmentId={departmentId}") ?? new List<Employee>();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}") ?? new Employee();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employees", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employees/{employee.EmployeeId}", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/employees/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Status>>($"api/status") ?? new List<Status>();
        }
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Department>>($"api/departments") ?? new List<Department>();
        }


    }
}