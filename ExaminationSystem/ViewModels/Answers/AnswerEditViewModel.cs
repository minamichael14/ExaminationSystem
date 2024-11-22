using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Answers
{
    public class AnswerEditViewModel
    {
        public int ID { get; set; }
    }

    public static class AnswerEditViewModelExtension
    {
        public static Answer ToModel(this AnswerEditViewModel viewModel)
        {
            var answer = ((AnswerEditViewModel)viewModel).ToModel();
            answer.ID = viewModel.ID;
            return answer;
        }
    }

}
