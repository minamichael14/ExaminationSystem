using ExaminationSystem.ViewModels.Courses;

namespace ExaminationSystem.Services.Courses
{
    public interface ICourseService
    {
        int Create(CourseCreateViewModel courseViewModel);
        void Delete(int CourseID);
        void Update(CourseEditViewModel viewModel);
        IEnumerable<CourseViewModel> GetAll();
    }
}
