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
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(User user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public ICollection<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _dbContext.Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Update(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UserExists(int id)
        {
            return _dbContext.Users.Any(c => c.Id == id);
        }
    }
}
