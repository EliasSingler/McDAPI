using System.Collections.Generic;
using IO.Swagger.Models;

namespace IO.Swagger.Data
{
    /// <summary>
    /// Employee repo interface
    /// </summary>
    public interface IEmployeeRepo
    {
        /// <summary>
        /// Saves changes to database
        /// </summary>
        public bool SaveChanges();
        /// <summary>
        /// Returns all employees
        /// </summary>
        public IEnumerable<Employee> GetAllEmployees();
        /// <summary>
        /// Returns employee of specific id
        /// </summary>
        public Employee GetEmployeeById(long? id);
        /// <summary>
        /// Adds employee to database
        /// </summary>
        public void AddEmployee(Employee emp);
        /// <summary>
        /// Deletes employee from database
        /// </summary>
        public void DeleteEmployee(long? id);

    }
}
