using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;
using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamViewModel
    {
        public int ID { get; set; }
        public int QuestionNumbers { get; set; }
        public int TotalGrade { get; set; }
        public bool isRandom { get; set; } = false;
        public bool isFinalExam { get; set; } = false;
        public int CourseID { get; set; }
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
