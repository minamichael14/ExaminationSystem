using ExaminationSystem.ViewModels.SubmittedAnswers;

namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamSubmitViewModel
    {
        public int ExamID { get; set; }
        public int StudentID { get; set; }
        public Dictionary<int, int> QuestionAnswer { get;set; }
    }
}
