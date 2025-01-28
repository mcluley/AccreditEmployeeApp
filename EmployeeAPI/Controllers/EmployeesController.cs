using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Data;
using EmployeeShared.Models;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/GetAllEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees(string sortColumn = "", string sortOrder = "", int statusId = 0, int departmentId = 0)
        {
            IQueryable<Employee> employees = _context.Employees
                .Include(e => e.Status)
                .Include(e => e.Department);

            // SORTING
            if (!string.IsNullOrEmpty(sortColumn))
            {
                switch (sortColumn)
                {
                    case "DepartmentDescription":
                        if (sortOrder == "desc")
                            employees = employees.OrderByDescending(e => e.Department.DepartmentDescription);
                        else
                            employees = employees.OrderBy(e => e.Department.DepartmentDescription);
                        break;
                    case "StatusDescription":
                        if (sortOrder == "desc")
                            employees = employees.OrderByDescending(e => e.Status.StatusDescription);
                        else
                            employees = employees.OrderBy(e => e.Status.StatusDescription);
                        break;
                    default:
                        if (sortOrder == "desc")
                            employees = employees.OrderByDescending(e => EF.Property<object>(e, sortColumn));
                        else
                            employees = employees.OrderBy(e => EF.Property<object>(e, sortColumn));
                        break;
                }
            }

            // FILTERING
            if (statusId > 0)
                employees = employees.Where(e => e.StatusID == statusId);

            if (departmentId > 0)
                employees = employees.Where(e => e.DepartmentID == departmentId);

            var result = await employees.ToListAsync();
            return Ok(result);

        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            // As Status & Description Tables are linked, this Prevents New Foreign Key Records Being Created in each of the tables which are not required. 
            _context.Entry(employee.Status).State = EntityState.Unchanged;
            _context.Entry(employee.Department).State = EntityState.Unchanged;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllEmployees), new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId) return BadRequest();

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.EmployeeId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}