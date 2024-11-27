using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionCreateViewModel :QuestionBaseViewModel
    {
        public int CourseID { get; set; }
        public ICollection<ChoiceCreateViewModel> Choices { get; set; }
    }

    public static class QuestionCreateViewModelExtension
    {
        public static Question ToModel(this QuestionCreateViewModel viewModel)
        {
            var question = ((QuestionBaseViewModel)viewModel).ToModel();
            question.CourseID = viewModel.CourseID;
            //question.Choices = viewModel.Choices.ToModel();
            return question;
        }
    }
}

