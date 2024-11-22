using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService : IQuestoionService
    {
        IRepository<Question> _questioRepository;

        public QuestionService()
        {
            _questioRepository = new Repository<Question>();
        }
        public void Add(QuestionCreateViewModel ViewModel)
        {
            _questioRepository.Add(ViewModel.ToModel());
            _questioRepository.SaveChanges();
        }

        public void Delete(int questionId)
        {
            var question = new Question { ID= questionId};
            _questioRepository.Delete(question);
            _questioRepository.SaveChanges();
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            return _questioRepository.Get().ToViewModel();
        }

        public QuestionViewModel GetById(int questionId)
        {
            return _questioRepository.GetByID(questionId).ToViewModel();
        }

        public void Update(QuestionEditViewModel ViewModel)
        {
            var question = ViewModel.ToModel();
            _questioRepository.SaveInclude(question, nameof(question.Body), nameof(question.Grade), nameof(question.level));
            _questioRepository.SaveChanges();
        }
    }
}
