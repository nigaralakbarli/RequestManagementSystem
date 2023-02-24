using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IRequestService
    {
        ICollection<Request> GetAll();
        Request? GetById(int id);
        bool Create(Request request);
        bool Update(Request request);
        bool Delete(Request request);
        bool RequestExists(int id);
    }
}
