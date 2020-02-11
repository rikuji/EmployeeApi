using Api.Data;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeRepository(Context context, IDepartmentRepository departmentRepository)
        {
            _context = context;
            _departmentRepository = departmentRepository;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee Find(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            var lst = new List<Employee>();

            var lstEmployee = _context.Employees.ToList();

            foreach (var item in lstEmployee)
            {
                var employee = new Employee
                {
                    ID = item.ID,
                    Name = item.Name,
                    DepartmentId = item.DepartmentId,
                    Department = _departmentRepository.Find(item.DepartmentId),
                    Email = item.Email,
                    DOJ = item.DOJ
                };
                lst.Add(employee);
            }

            return lst;
        }

        public void Remove(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.ID == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    }
}
