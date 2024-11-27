using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamRandomCreateViewModel
    {
        public int QuestionNumbers { get; set; }
        public int TotalGrade { get; set; }
        public bool isRandom { get; set; } = false;
        public bool isFinalExam { get; set; } = false;

        public int CourseID { get; set; }
    }
    public static class ExamRandomCreateViewModelExtension
    {
        public static Exam ToModel(this ExamRandomCreateViewModel viewModel)
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
