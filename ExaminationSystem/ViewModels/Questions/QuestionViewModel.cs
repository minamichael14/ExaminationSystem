using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionViewModel
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public int Grade { get; set; }
        public string level { get; set; }
    }

    public static class QuestionViewModelExtension
    {
        public static QuestionViewModel ToViewModel(this Question question)
        {
            return new QuestionViewModel
            {
                ID = question.ID,
                Body = question.Body,
                Grade = question.Grade,
                level = question.level
            };
        }


        public static IQueryable<QuestionViewModel> ToViewModel(this IQueryable<Question> questions)
        {
            return questions.Select(x => new QuestionViewModel
            {
                ID = x.ID,
                Body = x.Body,
                Grade = x.Grade,
                level = x.level
            });
        }
    }
}
