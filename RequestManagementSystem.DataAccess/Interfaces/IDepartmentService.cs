using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IDepartmentService
    {
        ICollection<Department> GetAll();
        Department? GetById(int id);
        bool Create(Department department);
        bool Update(Department department);
        bool Delete(Department department);
        bool DepartmentExists(int id);  
    }
}
