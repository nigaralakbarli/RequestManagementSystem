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

        //public List<Request> GetList(ListRequest listRequest)
        //{
        //    var queryble = _dbContext.Requests
        //                            .Include(r => r.Category)
        //                            .Include(r => r.Priority)
        //                            .Include(r => r.RequestType)
        //                            .Include(r => r.RequestStatus)
        //                            .Include(r => r.CreateUser)
        //                            .Include(r => r.ExecutorUser).AsQueryable();

        //    if (!string.IsNullOrEmpty(listRequest.Id))
        //    {
        //        queryble = queryble.Where(e => e.Id.ToString().Contains(listRequest.Id));
        //    }

        //    if (!string.IsNullOrEmpty(listRequest.Category))
        //    {
        //        queryble = queryble.Where(e => e.Category.Name.Trim().ToLower().Contains((listRequest.Category).Trim().ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(listRequest.Title))
        //    {
        //        queryble = queryble.Where(e => e.Title.Trim().ToLower().Contains((listRequest.Title).Trim().ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(listRequest.Description))
        //    {
        //        queryble = queryble.Where(e => e.Description.Trim().ToLower().Contains((listRequest.Description).Trim().ToLower()));
        //    }

        //    if (listRequest.CreatedAt.HasValue)
        //    {
        //        queryble = queryble.Where(e => e.CreatedAt == listRequest.CreatedAt);
        //    }

        //    if (!string.IsNullOrEmpty(listRequest.CreateUser))
        //    {
        //        queryble = queryble.Where(e => e.CreateUser.Name.Trim().ToLower().Contains((listRequest.CreateUser).Trim().ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(listRequest.ExecutorUser))
        //    {
        //        queryble = queryble.Where(e => e.ExecutorUser.Name.Trim().ToLower().Contains((listRequest.ExecutorUser).Trim().ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(listRequest.RequestStatus))
        //    {
        //        queryble = queryble.Where(e => e.RequestStatus.Name.Trim().ToLower().Contains((listRequest.RequestStatus).Trim().ToLower()));
        //    }

        //    return queryble.Skip((listRequest.pageIndex - 1) * listRequest.pageSize).Take(listRequest.pageSize).ToList(); ;
        //}

        public List<Request> GetList(ListRequest listRequest)
        {
            var queryable = _dbContext.Requests
                                        .Include(r => r.Category)
                                        .Include(r => r.Priority)
                                        .Include(r => r.RequestType)
                                        .Include(r => r.RequestStatus)
                                        .Include(r => r.CreateUser)
                                        .Include(r => r.ExecutorUser)
                                        .AsQueryable();

            var filters = new Dictionary<string, Func<IQueryable<Request>, string, IQueryable<Request>>>
                {
                    { "Id", (query, value) => query.Where(e => e.Id.ToString().Contains(value)) },
                    { "Category", (query, value) => query.Where(e => e.Category.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "Title", (query, value) => query.Where(e => e.Title.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "Description", (query, value) => query.Where(e => e.Description.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "CreatedAt", (query, value) => query.Where(e => e.CreatedAt == DateTime.Parse(value)) },
                    { "CreateUser", (query, value) => query.Where(e => e.CreateUser.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "ExecutorUser", (query, value) => query.Where(e => e.ExecutorUser.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                    { "RequestStatus", (query, value) => query.Where(e => e.RequestStatus.Name.Trim().ToLower().Contains(value.Trim().ToLower())) },
                };

            foreach (var kvp in filters)
            {
                var key = kvp.Key;
                var value = typeof(ListRequest).GetProperty(key)?.GetValue(listRequest)?.ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    queryable = kvp.Value(queryable, value);
                }
            }

            return queryable.Skip((listRequest.pageIndex - 1) * listRequest.pageSize)
                            .Take(listRequest.pageSize)
                            .ToList();
        }
    }
}
