using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Data.Models
{
    public class RequestType
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public ICollection<Request> Requests { get; set; }

    }
}
