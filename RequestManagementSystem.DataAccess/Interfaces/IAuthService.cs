using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface IAuthService
    {
        string Generate(User user);
        User Authenticate(UserLogin userLogin);
    }
}
