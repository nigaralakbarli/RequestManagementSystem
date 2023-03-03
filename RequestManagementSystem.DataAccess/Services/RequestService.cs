using Microsoft.EntityFrameworkCore;
using RequestManagementSystem.Data.DataContext;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Models;
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

        public ICollection<Request> GetAll(int pageIndex, int pageSize)
        {
            var requests =  _dbContext.Requests.OrderBy(r => r.Id)
                                    .Include(r => r.Priority)
                                    .Include(r => r.Category)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser)
                                    .ToList();
            return requests.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public ICollection<Request> GetAll()
        {
            return  _dbContext.Requests.OrderBy(r => r.Id)
                                    .Include(r => r.Priority)
                                    .Include(r => r.Category)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser)
                                    .ToList();
        }

        public Request? GetById(int id)
        {
            return _dbContext.Requests.Where(p => p.Id == id)
                                    .Include(r => r.Priority)
                                    .Include(r => r.Category)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).FirstOrDefault();
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

        public static void Check()
        {

        }

        public List<Request> GetList(ListRequest listRequest)
        {
            var queryble = _dbContext.Requests
                                    .Include(r => r.Category)
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).AsQueryable();

            if (!string.IsNullOrEmpty(listRequest.Id))
            {
                queryble = queryble.Where(e => e.Id.ToString().Contains(listRequest.Id));
            }
            
            //queryble = !string.IsNullOrEmpty(listRequest.Id) ? queryble.Where(e => e.Id.ToString().Contains(listRequest.Id)) : queryble;

            if (!string.IsNullOrEmpty(listRequest.Category))
            {
                queryble = queryble.Where(e => e.Category.Name.Trim().ToLower().Contains((listRequest.Category).Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(listRequest.Title))
            {
                queryble = queryble.Where(e => e.Title.Trim().ToLower().Contains((listRequest.Title).Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(listRequest.Description))
            {
                queryble = queryble.Where(e => e.Description.Trim().ToLower().Contains((listRequest.Description).Trim().ToLower()));
            }

            if (listRequest.CreatedAt.HasValue)
            {
                queryble = queryble.Where(e => e.CreatedAt == listRequest.CreatedAt);
            }

            if (!string.IsNullOrEmpty(listRequest.CreateUser))
            {
                queryble = queryble.Where(e => e.CreateUser.Name.Trim().ToLower().Contains((listRequest.CreateUser).Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(listRequest.ExecutorUser))
            {
                queryble = queryble.Where(e => e.ExecutorUser.Name.Trim().ToLower().Contains((listRequest.ExecutorUser).Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(listRequest.RequestStatus))
            {
                queryble = queryble.Where(e => e.RequestStatus.Name.Trim().ToLower().Contains((listRequest.RequestStatus).Trim().ToLower()));
            }

            return queryble.Skip((listRequest.pageIndex - 1) * listRequest.pageSize).Take(listRequest.pageSize).ToList(); ;
        }
    }
}
