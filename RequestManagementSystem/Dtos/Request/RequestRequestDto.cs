namespace RequestManagementSystem.Dtos.Request
{
    public class RequestRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUpload { get; set; }
        public int CreateUserId { get; set; }
        public int ExecutorUserId { get; set; }
        public int CategoryId { get; set; }
        public int RequestTypeId { get; set; }
        public int RequestStatusId { get; set; }
        public int PriorityId { get; set; }
    }
}
