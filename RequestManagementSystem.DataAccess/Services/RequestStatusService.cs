using Azure.Core;
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
    public class RequestStatusService : IRequestStatusService
    {
        private readonly AppDbContext _dbContext;
        public RequestStatusService(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public bool Create(RequestStatus requestStatus)
        {
            _dbContext.Add(requestStatus);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(RequestStatus requestStatus)
        {
            _dbContext.Remove(requestStatus);
            _dbContext.SaveChanges();
            return true;
        }

        public ICollection<RequestStatus> GetAll()
        {
            return _dbContext.RequestStatuses.OrderBy(p => p.Id).ToList();
        }

        public RequestStatus? GetById(int id)
        {
            return _dbContext.RequestStatuses.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool RequestStatusExists(int id)
        {
            return _dbContext.RequestStatuses.Any(p => p.Id == id);
        }

        public bool Update(RequestStatus requestStatus)
        {
            _dbContext.Update(requestStatus);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
