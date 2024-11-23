using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Courses;

namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceEditViewModel : ChoiceCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class ChoiceEditViewModelExtension
    {
        public static Choice ToModel(this ChoiceEditViewModel viewModel)
        {
            var choice = ((ChoiceCreateViewModel)viewModel).ToModel();
            choice.ID = viewModel.ID;
            return choice;
        }
    }

}
