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
            var question = new Question
            {
                ID = viewModel.ID,
                level = viewModel.level,
                Body = viewModel.Body,
                Grade = viewModel.Grade,
                CourseID = viewModel.CourseID
            };
            return question;
        }
    }

}
