using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Data.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUpload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User CreateUser { get; set; }
        public int CreateUserId { get; set; }
        public User ExecutorUser { get; set; }
        public int ExecutorUserId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public RequestType RequestType { get; set; }
        public int RequestTypeId { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public int RequestStatusId { get; set; }
        public Priority Priority { get; set; } 
        public int PriorityId { get; set; }
    }
}
