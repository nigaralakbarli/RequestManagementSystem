namespace RequestManagementSystem.Dtos.Request
{
    public class RequestList
    {
        public int pageIndex {  get; set; }
        public int pageSize { get; set; }
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Category { get; set; }
        public string? CreateUser { get; set; }
        public string? ExecutorUser { get; set; }
        public string? RequestStatus { get; set; }
    }
}
