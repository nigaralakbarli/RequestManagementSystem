using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Data.Models
{
    public class Action
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }  
        public Request Request { get; set; }
        public int RequestId { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public int RequestStatusId { get; set; }

    }
}
