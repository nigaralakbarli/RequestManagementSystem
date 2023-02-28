using RequestManagementSystem.Data.Models;

namespace RequestManagementSystem.Dtos.Response
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InternalNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool AllowNotification { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}
