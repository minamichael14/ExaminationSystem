using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Courses
{
    public class CourseViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
    }

    public static class CourseViewModelExtension
    {
        public static CourseViewModel ToViewModel(this Course course)
        {
            return new CourseViewModel
            {
                ID = course.ID,
                Name = course.Name,
                Description = course.Description,
                Hours = course.Hours
            };
        }


        public static IQueryable<CourseViewModel> ToViewModel(this IQueryable<Course> courses)
        {
            return courses.Select(x => new CourseViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                Hours = x.Hours
            });
        }
    } 
}
