using ExaminationSystem.Data.Repository;

namespace ExaminationSystem.Services.Answers
{
    public class AnswerService : IAnswerService
    {
    //    IRepository<Answer> _answerRepository;
    //    public AnswerService()
    //    {
    //        _answerRepository = new Repository<Answer>();
    //    }
    //    public void Add(AnswerCreateViewModel ViewModel)
    //    {
    //        _answerRepository.Add(ViewModel.ToModel());
    //        _answerRepository.SaveChanges();
    //    }

    //    public void Delete(int id)
    //    {
    //        var answer = new Answer { ID = id };
    //        _answerRepository.Delete(answer);
    //        _answerRepository.SaveChanges();
    //    }

    //    public IEnumerable<AnswerViewModel> GetAll()
    //    {
    //        return _answerRepository.Get().ToViewModel();
    //    }

    //    public AnswerViewModel GetById(int choiceId)
    //    {
    //        return _answerRepository.GetByID(choiceId).ToViewModel();
    //    }

    //    public void Update(AnswerEditViewModel ViewModel)
    //    {
    //        var answer = ViewModel.ToModel();
    //        _answerRepository.SaveInclude(answer , nameof(answer.ChoiceID));
    //        _answerRepository.SaveChanges();
    //    }
    }
}
