using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionViewModel
    {
        
        public int ID { get; set; }
        public string Body { get; set; }
        public int Grade { get; set; }
        public string level { get; set; }
        public ICollection<ChoiceViewModel> Choices { get; set; }

    }

    public static class QuestionViewModelExtension
    {
        public static QuestionViewModel ToViewModel(this Question question)
        {
            ICollection<ChoiceViewModel> _choices = question.Choices
                    .Select(choice => new ChoiceViewModel
                    {
                        Content = choice.Content,
                        ID = choice.ID,
                        QuestionID = choice.QuestionID,
                        Iscorrect = choice.ID == 0? true : false
                        
                    }).ToList();
            
            return new QuestionViewModel
            {
                ID = question.ID,
                Body = question.Body,
                Grade = question.Grade,
                level = question.level,
                Choices = _choices

            };
        }


        public static IQueryable<QuestionViewModel> ToViewModel(this IQueryable<Question> questions)
        {
            //ICollection<ChoiceViewModel> _choices = questions
            //    .Select(question => question.Choices.Select(
            //        choice => new ChoiceViewModel
            //           {
            //               Content = choice.Content,
            //               ID = choice.ID,
            //               QuestionID = choice.QuestionID
            //           })
            //        ));

            return questions.Select(x => new QuestionViewModel
            {
                ID = x.ID,
                Body = x.Body,
                Grade = x.Grade,
                level = x.level,
                Choices = new List<ChoiceViewModel> {  } //x.Choices.
            });
        }
    }
}
