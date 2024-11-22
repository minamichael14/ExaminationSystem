using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceViewModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int QuestionID { get; set; }

    }

    public static class ChoiceViewModelExtension
    {
        public static ChoiceViewModel ToViewModel(this Choice choice)
        {
            return new ChoiceViewModel
            {
                Content = choice.Content,
                QuestionID = choice.QuestionID
            };
        }


        public static IQueryable<ChoiceViewModel> ToViewModel(this IQueryable<Choice> choices)
        {
            return choices.Select(x => new ChoiceViewModel
            {
                Content= x.Content,
                QuestionID = x.QuestionID
            });
        }
    }
}
