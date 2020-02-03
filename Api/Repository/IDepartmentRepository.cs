using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public interface IDepartmentRepository
    {
        void Add(Department department);
        IEnumerable<Department> GetAll();
        Department Find(int id);
        void Remove(int id);
        void Update(Department department);
    }
}
