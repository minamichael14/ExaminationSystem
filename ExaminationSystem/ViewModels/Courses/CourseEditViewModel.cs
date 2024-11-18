using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Courses
{
    public class CourseEditViewModel:CourseCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class CourseEditViewModelExtension
    {
        public static Course ToModel(this CourseEditViewModel viewModel)
        {
            var course = ((CourseCreateViewModel)viewModel).ToModel();
            course.ID = viewModel.ID;
            return course;
        }
    }
}
