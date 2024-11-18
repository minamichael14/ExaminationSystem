using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Instructors;

namespace ExaminationSystem.Services.InstructorStudents
{
    public class InstructorCourseService : IInstructorCourseService
    {
        IRepository<InstructorCourse> _instructorCourseRepository;
        public InstructorCourseService()
        {
            _instructorCourseRepository = new Repository<InstructorCourse>();
        }
        public void AddInstructorToCourse(int CourseID, int InstructorID)
        {
            _instructorCourseRepository.Add(new InstructorCourse
            {
                CourseID = CourseID,
                InstructorID = InstructorID
            });

            _instructorCourseRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var instructorCourse = new InstructorCourse { ID = id };
            _instructorCourseRepository.Delete(instructorCourse);
        }

        public IQueryable<CourseViewModel> GetCourses(int instructorID)
        {
            return _instructorCourseRepository.Get().Where(x => x.InstructorID == instructorID).Select(x => x.Course).ToViewModel();
        }

        public IQueryable<InstructorViewModel> GetInstructors(int courseID)
        {
            return _instructorCourseRepository.Get().Where(x => x.CourseID == courseID).Select(x=>x.Instructor).ToViewModel();
        }

       
    }
}
