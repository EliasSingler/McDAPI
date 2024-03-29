/*
 * Test API for Project
 *
 * This is a test API for McDonald's internship 2022. The API is able to get, create, and delete employees. An employee has an id, a name, and a title.
 *
 * OpenAPI spec version: 1.0.2
 * Contact: elias.singler@us.mcd.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Data;
using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// controller
    /// </summary>
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly IEmployeeRepo _repo;
        /// <summary>
        /// Sets up employee repo
        /// </summary>
        public EmployeesApiController(IEmployeeRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Returns a list of all the employees in the database
        /// </summary>
        [HttpGet]
        [Route("/employees")]
        [ValidateModelState]
        [SwaggerOperation("EmployeesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Employee), description: "Successful pull of employees")]
        public virtual IActionResult EmployeesGet()
        {
            var employees = _repo.GetAllEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        /// <summary>
        /// Deletes an employee from database
        /// </summary>
        [HttpDelete]
        [Route("/employees/{id}")]
        [ValidateModelState]
        [SwaggerOperation("EmployeesIdDelete")]
        public virtual IActionResult EmployeesIdDelete([FromRoute][Required]long? id)
        {
            if(_repo.GetEmployeeById(id)==null)
            {
                return BadRequest();
            }
            _repo.DeleteEmployee(id);
            _repo.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Returns information from ID of a specific employee
        /// </summary>
        [HttpGet]
        [Route("/employees/{id}")]
        [ValidateModelState]
        [SwaggerOperation("EmployeesIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Employee), description: "Successfully obtained information about employee")]
        public virtual IActionResult EmployeesIdGet([FromRoute][Required]int? id)
        {
            if (_repo.GetEmployeeById(id) == null)
            {
                return BadRequest();
            }
            else return Ok(_repo.GetEmployeeById(id+1));
        }

        /// <summary>
        /// Adds a new employee to the database
        /// </summary>
        [HttpPost]
        [Route("/employees")]
        [ValidateModelState]
        [SwaggerOperation("EmployeesPost")]
        public virtual IActionResult EmployeesPost([FromBody]Employee body)
        {
            if(body == null)
            {
                return BadRequest();
            }
            _repo.AddEmployee(body);
            _repo.SaveChanges();
            return Ok();
        }
    }
}
