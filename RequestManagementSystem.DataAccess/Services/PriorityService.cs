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
    public class PriorityService : IPriorityService
    {
        private readonly AppDbContext _dbContext;
        public PriorityService(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public bool Create(Priority priority)
        {
            _dbContext.Add(priority);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Priority priority)
        {
            _dbContext.Remove(priority);
            _dbContext.SaveChanges();
            return true;
        }

        public ICollection<Priority> GetAll()
        {
            return _dbContext.Priorities.OrderBy(p => p.Id).ToList();
        }

        public Priority? GetById(int id)
        {
            return _dbContext.Priorities.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Request> GetRequestsByPriority(int priorityId)
        {
            return _dbContext.Requests.Where(r => r.PriorityId == priorityId).ToList();
        }

        public bool PriorityExists(int id)
        {
            return _dbContext.Priorities.Any(p => p.Id == id);
        }

        public bool Update(Priority priority)
        {
            _dbContext.Update(priority);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
