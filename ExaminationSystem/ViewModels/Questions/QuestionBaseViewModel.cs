using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionBaseViewModel
    {
        public string Body { get; set; }
        public int Grade { get; set; }
        public string level { get; set; }
        public int CorrectChoiceOrder { get; set; }
        
    }

    public static class QuestionBaseViewModelExtension
    {
        public static Question ToModel(this QuestionBaseViewModel viewModel)
        {
            return new Question
            {
                level = viewModel.level,
                Body = viewModel.Body,
                Grade = viewModel.Grade,
                CorrectChoiceOrder = viewModel.CorrectChoiceOrder
            };
        }
    }
}
