using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Students;

namespace ExaminationSystem.Services.StudentCourses
{
    public class StudentCourseService:IStudentCourseService
    {
        IRepository<StudentCourse> _studentCourseRepository;
        public StudentCourseService()
        {
            _studentCourseRepository = new Repository<StudentCourse>();
        }

        public void EnrollStudentInCourse(int courseID, int studentID , int InstructorID)
        {
            _studentCourseRepository.Add(new StudentCourse
            {
                CourseID = courseID,
                StudentID = studentID,
                CreatedBy = InstructorID
            });

            _studentCourseRepository.SaveChanges();
        }

        public IQueryable<CourseViewModel> GetCourses(int studentID)
        {
            return _studentCourseRepository.Get()
                .Where(x => x.StudentID == studentID)
                .Select(x => x.Course)
                .ToViewModel();
        }

        public IQueryable<StudentViewModel> GetStudents(int courseID)
        {
            return _studentCourseRepository.Get()
                .Where(x => x.CourseID == courseID)
                .Select(x=>x.Student)
                .ToViewModel();
        }
    }
}
