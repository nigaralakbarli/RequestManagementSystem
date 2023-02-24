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
    public class RequestTypeService : IRequestTypeService
    {
        private readonly AppDbContext _dbContext;
        public RequestTypeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(RequestType requestType)
        {
            _dbContext.Add(requestType);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(RequestType requestType)
        {
            _dbContext.Remove(requestType);
            _dbContext.SaveChanges();
            return true;
        }

        public ICollection<RequestType> GetAll()
        {
            return _dbContext.RequestTypes.OrderBy(p => p.Id).ToList();
        }

        public RequestType? GetById(int id)
        {
            return _dbContext.RequestTypes.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool RequestTypeExists(int id)
        {
            return _dbContext.RequestTypes.Any(p => p.Id == id);
        }

        public bool Update(RequestType requestType)
        {
            _dbContext.Update(requestType);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
