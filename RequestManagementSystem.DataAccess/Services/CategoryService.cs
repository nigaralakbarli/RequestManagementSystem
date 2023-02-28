using Microsoft.EntityFrameworkCore;
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
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;
        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Category category)
        {
            _dbContext.Add(category);
            _dbContext.SaveChanges();
            return true;
        }
        public ICollection<Category> GetAll()
        {
            return _dbContext.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category? GetById(int id)
        {
            return _dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Update(Category category)
        {
            _dbContext.Update(category);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(Category category)
        {
            _dbContext.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CategoryExists(int id)
        {
            return _dbContext.Categories.Any(c => c.Id == id);
        }

        public ICollection<Request> GetRequestsByCategory(int categoryId)
        {
            return _dbContext.Requests.Where(r => r.CategoryId == categoryId)
                           .Include(r => r.Category)
                           .Include(r => r.Priority)
                           .Include(r => r.RequestType)
                           .Include(r => r.RequestStatus)
                           .Include(r => r.CreateUser)
                           .Include(r => r.ExecutorUser).ToList();
        }
    }
}
