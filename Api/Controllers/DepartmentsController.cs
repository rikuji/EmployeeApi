using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var departament = _departmentRepository.Find(id);

            if (departament == null)
                return NotFound();

            return new ObjectResult(departament);
        }

        [HttpPost]
        public void Post([FromBody] Department department)
        {
            _departmentRepository.Add(department);
        }

        [HttpPut]
        public void Put([FromBody]Department department)
        {
            _departmentRepository.Update(department);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentRepository.Remove(id);
        }
    }
}
