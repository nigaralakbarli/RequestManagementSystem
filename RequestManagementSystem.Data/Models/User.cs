using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InternalNumber  { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }   
        public bool AllowNotification { get; set; }
        public string Position { get; set; }

        //public ICollection<Request> Requests { get; set; }
        public ICollection<Request> CreatedRequests { get; set; }
        public ICollection<Request> ExecutedRequests { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}   
