namespace ExaminationSystem.ViewModels.SubmittedAnswers
{
    public class SubmittedAnswerCreateViewModel
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public int StudentID { get; set; }
        public int Choiceorder { get; set; }
        public bool IsCorrect { get; set; }
    }
}
