using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Courses
{
    public class CourseCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int InstrucorID { get; set; }
    }

    public static class CourseCreateViewModelExtension
    {
        public static Course ToModel(this CourseCreateViewModel viewModel)
        {
            return new Course
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Hours = viewModel.Hours
            };
        }
    }
}
