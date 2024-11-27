namespace ExaminationSystem.Models
{
    public class Instructor:BaseModel
    {
        public Instructor()
        {
            InstructorCourses = new List<InstructorCourse>();

        }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ICollection<InstructorCourse> InstructorCourses { get; set; }
    }
}
