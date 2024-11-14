using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Instructors
{
    public class InstructorEditViewModel:InstructorCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class InstructorEditViewModelExtension
    {
        public static Instructor ToModel(this InstructorEditViewModel viewModel)
        {
            var instructor = ((InstructorCreateViewModel)viewModel).ToModel();
            instructor.ID = viewModel.ID;
            return instructor;
        }
    }
}
