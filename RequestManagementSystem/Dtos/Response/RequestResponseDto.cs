using RequestManagementSystem.Data.Models;

namespace RequestManagementSystem.Dtos.Response
{
    public class RequestResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUpload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Category { get; set; }
        public string CreateUser { get; set; }
        public string ExecutorUser { get; set; }
        public string Priority { get; set; }
        public string RequestStatus { get; set; }
        public string RequestType { get; set; }
    }
}
