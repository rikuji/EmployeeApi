using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
         
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeRepository.Find(id);

            if (employee == null)
                return NotFound();

            return new ObjectResult(employee);
        }

        [HttpPost]
        public string Post([FromBody] Employee employee)
        {
            try
            {
                _employeeRepository.Add(employee);

                return "Added Successfully";

            }
            catch (Exception)
            {
                return "Failed to Add";
            }
            
        }

        [HttpPut]
        public string Put([FromBody]Employee employee)
        {
            try
            {
                _employeeRepository.Update(employee);

                return "Edited Successfully";

            }
            catch (Exception)
            {
                return "Failed to Edit";
            }
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeRepository.Remove(id);
        }
    }
}
