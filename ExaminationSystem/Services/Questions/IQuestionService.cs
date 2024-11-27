using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestoionService
    {
        IEnumerable<QuestionViewModel> GetAll();
        IEnumerable<QuestionViewModel> GetByCourse(int courseID);
        QuestionViewModel GetById(int questionId);
        IEnumerable<int> GetRandomQuestions(int courseID, int questionsNumber);
        void Add(QuestionCreateViewModel ViewModel);
        void Update(QuestionEditViewModel ViewModel);

        void Delete(int questionId);

    }
}
