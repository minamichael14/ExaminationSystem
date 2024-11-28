using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.Services.Choices
{
    public class ChoiceService : IChoiceService
    {
        IRepository<Choice> _choiceRepository;

        public ChoiceService()
        {
            _choiceRepository = new Repository<Choice>();
        }
        public void Add(ICollection<ChoiceCreateViewModel> ViewModel)
        {
            var choices = ViewModel.ToModel();
            foreach (var choice in choices)
            {
                _choiceRepository.Add(choice);
            }
            _choiceRepository.SaveChanges();         
        }

        public void Delete(int questionID)
        {
            var choices = _choiceRepository.Get().Where(x => x.QuestionID == questionID).Select(x=>x.ID).ToList();
            foreach (var choice in choices)
            {
                _choiceRepository.Delete(new Choice { ID = choice});
            }
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

        public void Update(ICollection<ChoiceEditViewModel> ViewModels)
        {
            var questionID =ViewModels.Select(x => x.QuestionID).FirstOrDefault();
            var choiceIDs = _choiceRepository.Get().Where(x => x.QuestionID == questionID).Select(x => x.ID).ToList();
            var deletedChoicesID = choiceIDs.Except(ViewModels.Select(x => x.ID)).ToList();
            

            foreach (var item  in ViewModels)
            {
                var choice = item.ToModel();

                if (choiceIDs.Contains(item.ID))
                {
                    _choiceRepository.SaveInclude(choice, nameof(choice.Content), nameof(choice.Order));
                }
                else
                {
                    _choiceRepository.Add(choice);
                }  
            }

            foreach (var choiceID in deletedChoicesID)
            {
                _choiceRepository.Delete(new Choice { ID = choiceID });
            }
            _choiceRepository.SaveChanges();
        }

    }
}
