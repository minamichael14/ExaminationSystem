namespace ExaminationSystem.Models
{
    public class Student:BaseModel
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
            Results = new List<Result>();
            submittedAnswers = new List<SubmittedAnswer>();
        }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<SubmittedAnswer> submittedAnswers { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
