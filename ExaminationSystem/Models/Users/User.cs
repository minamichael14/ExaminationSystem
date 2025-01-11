using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Models.Users
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
