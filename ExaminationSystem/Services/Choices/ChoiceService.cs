using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Answers;
using ExaminationSystem.ViewModels.Answers;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.Services.Choices
{
    public class ChoiceService : IChoiceService
    {
        IRepository<Choice> _choiceRepository;
        IAnswerService _answerService;


        public ChoiceService()
        {
            _choiceRepository = new Repository<Choice>();
            _answerService = new AnswerService();
        }
        public void Add(ChoiceCreateViewModel ViewModel)
        {
            var choice = ViewModel.ToModel();
            _choiceRepository.Add(choice);
            _choiceRepository.SaveChanges();
            if (ViewModel.Iscorrect)
            {
                var answerViewModel = new AnswerCreateViewModel
                {
                    ChoiceID = choice.ID,
                    QuestioID = choice.QuestionID
                };
                _answerService.Add(answerViewModel);
            }
        
        }

        public void Delete(int id)
        {
            var choice = new Choice { ID = id };
            _choiceRepository.Delete(choice);
            _choiceRepository.SaveChanges();
        }

        public IEnumerable<ChoiceViewModel> GetAll()
        {
            return _choiceRepository.Get().ToViewModel();
        }

        public ChoiceViewModel GetById(int choiceID)
        {
            return _choiceRepository.GetByID(choiceID).ToViewModel();
        }

        public void Update(ChoiceEditViewModel ViewModel)
        {
            var choice = ViewModel.ToModel();
            _choiceRepository.SaveInclude(choice, nameof(choice.Content));
            _choiceRepository.SaveChanges();
            

        }

    }
}
