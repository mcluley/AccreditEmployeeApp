using EmployeeShared.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options) { }
    }

}

