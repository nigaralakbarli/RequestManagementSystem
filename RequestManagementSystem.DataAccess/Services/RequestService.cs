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
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _dbContext;
        public RequestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Request request)
        {
            _dbContext.Add(request);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Request request)
        {
            _dbContext.Remove(request);
            _dbContext.SaveChanges();
            return true;
        }

        public ICollection<Request> GetAll()
        {
            return _dbContext.Requests.OrderBy(p => p.Id).ToList();
        }

        public Request? GetById(int id)
        {
            return _dbContext.Requests.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool RequestExists(int id)
        {
            return _dbContext.Requests.Any(p => p.Id == id);
        }

        public bool Update(Request request)
        {
            _dbContext.Update(request);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
