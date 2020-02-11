using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public string Post([FromBody] Department department)
        {
            try
            {
                _departmentRepository.Add(department);

                return "Added Successfully";

            } catch(Exception)
            {
                return "Failed to Add";
            }
            
        }

        [HttpPut]
        public string Put([FromBody]Department department)
        {
            try
            {
                _departmentRepository.Update(department);

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
            _departmentRepository.Remove(id);
        }
    }
}
