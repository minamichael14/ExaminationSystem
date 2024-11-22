using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Answers
{
    public class AnswerCreateViewModel
    {
        public int QuestioID { get; set; }
        public int ChoiceID { get; set; }
    }

    public static class AnswerCreateViewModelExtension
    {
        public static Answer ToModel(this AnswerCreateViewModel viewModel)
        {
            return new Answer
            {
                QuestionID = viewModel.QuestioID,
                ChoiceID = viewModel.ChoiceID
            };
        }
    }

}
