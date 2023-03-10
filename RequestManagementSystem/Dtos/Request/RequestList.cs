namespace RequestManagementSystem.Dtos.Request
{
    public class RequestList
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 2;
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? CreateUser { get; set; }
        public string? ExecutorUser { get; set; }
        public string? RequestStatus { get; set; }
    }
}
