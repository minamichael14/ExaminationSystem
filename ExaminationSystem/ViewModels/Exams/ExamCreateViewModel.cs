using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamCreateViewModel
    {
        public int QuestionNumbers { get; set; }
        public int TotalGrade { get; set; }
        public bool isRandom { get; set; } = false;
        public bool isFinalExam { get; set; } = false;
        public int CourseID { get; set; }
        public ICollection<int> QuestionIDs { get; set; }
    }

    public static class ExamCreateViewModelExtension
    {
        public static Exam ToModel(this ExamCreateViewModel viewModel)
        {
            return new Exam
            {
                QuestionNumbers = viewModel.QuestionNumbers,
                TotalGrade = viewModel.TotalGrade,
                isRandom = viewModel.isRandom,
                CourseID = viewModel.CourseID,
                isFinalExam = viewModel.isFinalExam,
            };

        }
    }
}
