using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Answers;
using ExaminationSystem.ViewModels.Choices;
using ExaminationSystem.ViewModels.Courses;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionCreateViewModel :QuestionBaseViewModel
    {
        public ICollection<ChoiceCreateViewModel> Choices { get; set; }
    }

    public static class QuestionCreateViewModelExtension
    {
        public static Question ToModel(this QuestionCreateViewModel viewModel)
        {
            return new Question
            {
                level = viewModel.level,
                Body = viewModel.Body,
                Grade = viewModel.Grade,
                CourseID = viewModel.CourseID
            };
        }
    }
}

