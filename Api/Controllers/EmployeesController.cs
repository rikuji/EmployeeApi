using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public void Post([FromBody] Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        [HttpPut]
        public void Put([FromBody]Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeRepository.Remove(id);
        }
    }
}
