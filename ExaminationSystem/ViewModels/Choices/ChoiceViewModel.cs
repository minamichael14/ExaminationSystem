using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceViewModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int QuestionID { get; set; }
        //public bool Iscorrect { get; set; } = false;
        public int Order { get; set; }


    }

    public static class ChoiceViewModelExtension
    {
        public static ChoiceViewModel ToViewModel(this Choice choice)
        {
            return new ChoiceViewModel
            {
                ID = choice.ID,
                Content = choice.Content,
                QuestionID = choice.QuestionID,
                Order = choice.Order
            };
        }


        public static IQueryable<ChoiceViewModel> ToViewModel(this IQueryable<Choice> choices)
        {
            return choices.Select(x => new ChoiceViewModel
            {
                ID = x.ID,
                Content= x.Content,
                QuestionID = x.QuestionID,
                Order = x.Order
            });
        }

        //public static ICollection<ChoiceViewModel> ToViewModel(this ICollection<Choice> choices)
        //{
        //    return choices.Select(x => new ChoiceViewModel
        //    {
        //        ID = x.ID,
        //        Content = x.Content,
        //        QuestionID = x.QuestionID
        //    });
        //}
    }
}
