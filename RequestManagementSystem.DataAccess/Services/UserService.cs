using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RequestManagementSystem.Data.DataContext;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
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
            return _dbContext.Users.OrderBy(r => r.Id).Include(r => r.Department).ToList();
        }


        public User? GetById(int id)
        {
            return _dbContext.Users.Where(c => c.Id == id).Include(r => r.Department).FirstOrDefault();
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

        public User GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _dbContext.Users.Include(r => r.Department).FirstOrDefault(o => o.Name.ToLower() == userId.ToLower());
        }
    }
}
