using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IRequestStatusService 
    {
        ICollection<RequestStatus> GetAll();
        ICollection<Request> GetRequestsByRequestStatus(int requestStatusId);
        RequestStatus? GetById(int id);
        bool Create(RequestStatus requestStatus);
        bool Update(RequestStatus requestStatus);
        bool Delete(RequestStatus requestStatus);
        bool RequestStatusExists(int id);   
    }
}
