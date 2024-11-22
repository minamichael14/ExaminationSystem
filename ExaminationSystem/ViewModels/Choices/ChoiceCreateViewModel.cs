using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceCreateViewModel
    {
        public string Content { get; set; }
        public int QuestionID { get; set; }

    }

    public static class ChoiceCreateViewModelExtension
    {
        public static Choice ToModel(this ChoiceCreateViewModel viewModel)
        {
            return new Choice
            {
                Content = viewModel.Content,
                QuestionID = viewModel.QuestionID
            };
        }
    }
}

