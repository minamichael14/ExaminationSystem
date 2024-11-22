using ExaminationSystem.ViewModels.Answers;

namespace ExaminationSystem.Services.Answers
{
    public interface IAnswerService
    {
        IEnumerable<AnswerViewModel> GetAll();
        AnswerViewModel GetById(int choiceId);

        void Add(AnswerCreateViewModel ViewModel);
        void Update(AnswerEditViewModel ViewModel);
        void Delete(int id);
    }
}
