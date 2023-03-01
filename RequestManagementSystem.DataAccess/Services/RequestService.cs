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
        public ICollection<Request> GetByPage(int pageIndex, int pageSize, ICollection<Request> requests)
        {
            return requests.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public ICollection<Request> GetAll()
        {
            return _dbContext.Requests.OrderBy(r => r.Id)
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



        public ICollection<Request> GetRequestsByCategory(string category)
        {
            return _dbContext.Requests.Where(r => r.Category.Name.Trim().ToLower().Contains(category.Trim().ToLower()))
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
        }

        public ICollection<Request> GetRequestsByCreateUser(string user)
        {
            return _dbContext.Requests.Where(r => r.CreateUser.Name.Trim().ToLower().Contains(user.Trim().ToLower()))
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
        }

        public ICollection<Request> GetRequestsByDate(DateTime date)
        {
            return _dbContext.Requests.Where(r => r.CreatedAt == date)
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
        }

        public ICollection<Request> GetRequestsByDescription(string description)
        {
            return _dbContext.Requests.Where(r => r.Description.Trim().ToLower().Contains(description.Trim().ToLower()))
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
        }

        public ICollection<Request> GetRequestsByExecuterUser(string user)
        {
            return _dbContext.Requests.Where(r => r.ExecutorUser.Name.Trim().ToLower().Contains(user.Trim().ToLower()))
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
        }

        public ICollection<Request> GetRequestsByStatus(string status)
        {
            return _dbContext.Requests.Where(r => r.RequestStatus.Name.Trim().ToLower().Contains(status.Trim().ToLower()))
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
        }

        public ICollection<Request> GetRequestsByTitle(string title)
        {
            return _dbContext.Requests.Where(r => r.Title.Trim().ToLower().Contains(title.Trim().ToLower()))
                                    .Include(r => r.Category)
                                    .Include(r => r.Priority)
                                    .Include(r => r.RequestType)
                                    .Include(r => r.RequestStatus)
                                    .Include(r => r.CreateUser)
                                    .Include(r => r.ExecutorUser).ToList();
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
            //if (!string.IsNullOrEmpty(listRequest.Id))
            //{
            //    queryble = queryble.Where(e => e.Id.ToString().Contains(listRequest.Id));
            //}

            queryble = queryble.Skip(1).Take(10);
            return queryble.ToList();
        }
    }
}
