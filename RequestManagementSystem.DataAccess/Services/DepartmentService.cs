using RequestManagementSystem.Data.DataContext;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _dbContext;
        public DepartmentService(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public bool Create(Department department)
        {
            _dbContext.Add(department);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Department department)
        {
            _dbContext.Remove(department);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DepartmentExists(int id)
        {
            return _dbContext.Departments.Any(c => c.Id == id);

        }

        public ICollection<Department> GetAll()
        {
            return _dbContext.Departments.OrderBy(c => c.Id).ToList();
        }

        public Department? GetById(int id)
        {
            return _dbContext.Departments.Where(c => c.Id == id).FirstOrDefault();

        }

        public bool Update(Department department)
        {
            _dbContext.Update(department);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
