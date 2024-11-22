using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Answers
{
    public class AnswerViewModel
    {
        public int ID { get; set; }
        public int QuestioID { get; set; }
        public int ChoiceID { get; set; }
    }

    public static class AnswerViewModelExtension
    {
        public static AnswerViewModel ToViewModel(this Answer answer)
        {
            return new AnswerViewModel
            {
                ChoiceID = answer.ChoiceID,
                QuestioID = answer.QuestionID
            };
        }


        public static IQueryable<AnswerViewModel> ToViewModel(this IQueryable<Answer> answers)
        {
            return answers.Select(x => new AnswerViewModel
            {
                QuestioID = x.QuestionID,
                ChoiceID = x.ChoiceID
            });
        }
    }
}
