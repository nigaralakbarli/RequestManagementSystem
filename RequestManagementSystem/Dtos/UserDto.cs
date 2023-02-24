using RequestManagementSystem.Data.Models;

namespace RequestManagementSystem.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InternalNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool AllowNotification { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
    }
}
