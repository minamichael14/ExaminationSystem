using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Answers
{
    public class AnswerEditViewModel:AnswerCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class AnswerEditViewModelExtension
    {
        public static Answer ToModel(this AnswerEditViewModel viewModel)
        {
            var answer = ((AnswerCreateViewModel)viewModel).ToModel();
            answer.ID = viewModel.ID;
            return answer;
        }
    }

}
