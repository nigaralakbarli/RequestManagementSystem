using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Data.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string Level { get; set; } = null!;
        public ICollection<Request> Requests { get; set; }
    }
}
