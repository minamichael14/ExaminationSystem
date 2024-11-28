namespace ExaminationSystem.Models
{
    public class Exam : BaseModel
    {
        public Exam()
        {
            ExamQuestions = new List<ExamQuestion>();
            Results = new List<Result>();
        }
        public int QuestionNumbers { get; set; }
        public int TotalGrade { get; set; }
        public bool isRandom { get; set; } = false;
        public bool isFinalExam { get; set; } = false;
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
