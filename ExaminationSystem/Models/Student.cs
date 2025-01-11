using ExaminationSystem.Models.Users;

namespace ExaminationSystem.Models
{
    public class Student:User
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
            Results = new List<Result>();
            submittedAnswers = new List<SubmittedAnswer>();
        }
        public int Grade { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<SubmittedAnswer> submittedAnswers { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
