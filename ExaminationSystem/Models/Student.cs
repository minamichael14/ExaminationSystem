namespace ExaminationSystem.Models
{
    public class Student:BaseModel
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();

        }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
