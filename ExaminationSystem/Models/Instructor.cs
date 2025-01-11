using ExaminationSystem.Models.Users;

namespace ExaminationSystem.Models
{
    public class Instructor:User
    {
        public Instructor()
        {
            InstructorCourses = new List<InstructorCourse>();

        }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }
    }
}
