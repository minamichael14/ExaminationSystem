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
        public void Add(ChoiceCreateViewModel ViewModel)
        {
            _choiceRepository.Add(ViewModel.ToModel());
            _choiceRepository.SaveChanges();
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
