using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionEditViewModel : QuestionCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class QuestionEditViewModelExtension
    {
        public static Question ToModel(this QuestionEditViewModel viewModel)
        {
            var question = ((QuestionEditViewModel)viewModel).ToModel();
            question.ID = viewModel.ID;
            return question;
        }
    }

}
