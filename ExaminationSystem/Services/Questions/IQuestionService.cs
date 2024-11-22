using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestoionService
    {
        IEnumerable<QuestionViewModel> GetAll();
        QuestionViewModel GetById(int questionId);

        void Add(QuestionCreateViewModel ViewModel);
        void Update(QuestionEditViewModel ViewModel);

        void Delete(int questionId);

    }
}
