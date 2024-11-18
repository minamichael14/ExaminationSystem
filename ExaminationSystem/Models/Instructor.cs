namespace ExaminationSystem.Models
{
    public class Instructor:BaseModel
    {
        public Instructor()
        {
            InstructorCourses = new List<InstructorCourse>();
            InstructorStudents = new List<InstructorStudent>(); 

        }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ICollection<InstructorCourse> InstructorCourses { get; set; }
        public ICollection<InstructorStudent> InstructorStudents { get; set; }
    }
}
