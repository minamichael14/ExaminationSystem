using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionEditViewModel : QuestionBaseViewModel
    {
        public int ID { get; set; }
        public ICollection<ChoiceEditViewModel> Choices { get; set; }
    }

    public static class QuestionEditViewModelExtension
    {
        public static Question ToModel(this QuestionEditViewModel viewModel)
        {
            var question = ((QuestionBaseViewModel)viewModel).ToModel();
            question.ID = viewModel.ID;
            return question;
        }
    }

}
