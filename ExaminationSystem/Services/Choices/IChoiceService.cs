using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceService
    {
        IEnumerable<ChoiceViewModel> GetAll();
        ChoiceViewModel GetById(int choiceId);
        void Add(ICollection<ChoiceCreateViewModel> ViewModel);
        public void Update(ICollection<ChoiceEditViewModel> ViewModels);
        void Delete(int id);

    }
}
