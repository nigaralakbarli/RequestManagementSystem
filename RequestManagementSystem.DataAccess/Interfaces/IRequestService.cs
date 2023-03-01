using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IRequestService
    {
        ICollection<Request> GetByPage(int pageIndex, int pageSize , ICollection<Request> requests);
        ICollection<Request> GetAll();
        ICollection<Request> GetRequestsByCreateUser(string user);
        ICollection<Request> GetRequestsByExecuterUser(string user);
        ICollection<Request> GetRequestsByDescription(string description);
        ICollection<Request> GetRequestsByCategory(string category);
        ICollection<Request> GetRequestsByTitle(string title);
        ICollection<Request> GetRequestsByDate(DateTime date);
        ICollection<Request> GetRequestsByStatus(string status);

        Request? GetById(int id);
        bool Create(Request request);
        bool Update(Request request);
        bool Delete(Request request);
        bool RequestExists(int id);
        List<Request> GetList(ListRequest listRequest);
    }
}
