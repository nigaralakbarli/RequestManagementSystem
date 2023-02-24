using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IUserService
    {
        ICollection<User> GetAll();
        User? GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(User user);
        bool UserExists(int id);

    }
}
