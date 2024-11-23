using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceViewModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int QuestionID { get; set; }
        public bool Iscorrect { get; set; } = false;


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
            };
        }


        public static IQueryable<ChoiceViewModel> ToViewModel(this IQueryable<Choice> choices)
        {
            return choices.Select(x => new ChoiceViewModel
            {
                ID = x.ID,
                Content= x.Content,
                QuestionID = x.QuestionID
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
