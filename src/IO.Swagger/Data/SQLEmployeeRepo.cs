using IO.Swagger.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace IO.Swagger.Data
{
    /// <summary>
    /// Implements employee repo interface
    /// </summary>
    public class SQLEmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _context;
        /// <summary>
        /// Sets up employee context
        /// </summary>
        public SQLEmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Saves changes to database
        /// </summary>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        /// <summary>
        /// Returns all employees
        /// </summary>
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        /// <summary>
        /// Returns employee of specific id
        /// </summary>
        public Employee GetEmployeeById(long? id)
        {
            return _context.Employees.FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// Adds employee to database
        /// </summary>
        public void AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
        }
        /// <summary>
        /// Deletes employee from database
        /// </summary>
        public void DeleteEmployee(long? id)
        {
            Employee emp = GetEmployeeById(id);
            _context.Employees.Remove(emp);
        }

    }
}
