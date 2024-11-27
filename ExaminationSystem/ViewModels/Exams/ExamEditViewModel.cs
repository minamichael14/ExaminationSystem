using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamEditViewModel: ExamCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class ExamEditViewModelExtension
    {
        public static Exam ToModel(this ExamEditViewModel viewModel)
        {
            var exam = ((ExamCreateViewModel)viewModel).ToModel();
            exam.ID = viewModel.ID;
            return exam;
        }
    }
}
