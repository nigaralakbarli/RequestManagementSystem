using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IRequestTypeService
    {
        ICollection<RequestType> GetAll();
        ICollection<Request> GetRequestsByRequestType(int requestTypeId);
        RequestType? GetById(int id);
        bool Create(RequestType requestType);
        bool Update(RequestType requestType);
        bool Delete(RequestType requestType);
        bool RequestTypeExists(int id);
    }
}
