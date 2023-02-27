using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.DataAccess.Interfaces
{
    public interface ICategoryService
    {
        ICollection<Category> GetAll();
        ICollection<Request> GetRequestsByCategory(int categoryId);
        Category? GetById(int id);
        bool Create(Category category);
        bool Update(Category category); 
        bool Delete(Category category);
        bool CategoryExists(int id);
    }
}
