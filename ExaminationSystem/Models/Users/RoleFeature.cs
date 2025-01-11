using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Models.Users
{
    public class RoleFeature:BaseModel
    {
        public Role Role { get; set; }
        public Feature Feature { get; set; }
    }
}
