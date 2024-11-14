using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Instructors
{
    public class InstructorCreateViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public static class InstructorCreateViewModelExtension
    {
        public static Instructor ToModel(this InstructorCreateViewModel viewModel)
        {
            return new Instructor
            {
                Name = viewModel.Name,
                Phone = viewModel.Phone
            };
        }
    }
}
