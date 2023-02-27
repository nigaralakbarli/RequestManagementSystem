using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IPriorityService
    {
        ICollection<Priority> GetAll();
        //ICollection<Request> GetRequestsByPriority(int priorityId);
        Priority? GetById(int id);
        bool Create(Priority priority);
        bool Update(Priority priority);
        bool Delete(Priority priority);
        bool PriorityExists(int id);    
    }
}
