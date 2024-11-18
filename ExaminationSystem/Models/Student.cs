namespace ExaminationSystem.Models
{
    public class Student:BaseModel
    {
        public Student()
        {
            InstructorStudents = new List<InstructorStudent>();
            StudentCourses = new List<StudentCourse>();

        }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public ICollection<InstructorStudent> InstructorStudents { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
