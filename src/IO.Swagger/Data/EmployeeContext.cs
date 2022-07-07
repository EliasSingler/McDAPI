using Microsoft.EntityFrameworkCore;
using IO.Swagger.Models;

namespace IO.Swagger.Data
{
    /// <summary>
    /// Bridge between API and database
    /// </summary>
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// Constructor for employee context
        /// </summary>
        public EmployeeContext(DbContextOptions<EmployeeContext> opt) : base(opt)
        {
        }
        /// <summary>
        /// Employee DBset
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}
