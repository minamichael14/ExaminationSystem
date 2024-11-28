namespace ExaminationSystem.Models
{
    public class SubmittedAnswer:BaseModel
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public int ChoiceOrder { get; set; }
        public bool IsCorrect { get; set; }
    }
}
