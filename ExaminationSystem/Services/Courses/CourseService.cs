using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Courses;

namespace ExaminationSystem.Services.Courses
{
    public class CourseService : ICourseService
    {
        IRepository<Course> _courserepository;
        public CourseService()
        {
            _courserepository = new Repository<Course>();            
        }
        public int Create(CourseCreateViewModel courseViewModel)
        {
            var course = courseViewModel.ToModel();
            _courserepository.Add(course);
            _courserepository.SaveChanges();
            return course.ID;
        }
        public void Delete(int CourseID)
        {
            var course = new Course { ID = CourseID };
            _courserepository.Delete(course);
            _courserepository.SaveChanges();
        }
        public IEnumerable<CourseViewModel> GetAll()
        {
            return _courserepository.Get().ToViewModel();
        }

        public CourseViewModel GetByID(int id)
        {
           return _courserepository.GetByID(id).ToViewModel();
        }

        public bool IsExist(int id)
        {
            return _courserepository.IsExist(id);
        }



        public void Update(CourseEditViewModel viewModel)
        {
            var course = viewModel.ToModel();
            _courserepository.SaveInclude(course, nameof(course.Name), nameof(course.Description), nameof(course.Hours));
            _courserepository.SaveChanges();
        }
    }
}
