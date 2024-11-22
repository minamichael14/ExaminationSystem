using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.Services.Choices
{
    public interface IChoiceService
    {
        IEnumerable<ChoiceViewModel> GetAll();
        ChoiceViewModel GetById(int choiceId);

        void Add(ChoiceCreateViewModel ViewModel);
        void Update(ChoiceEditViewModel ViewModel);
        void Delete(int id);

    }
}
