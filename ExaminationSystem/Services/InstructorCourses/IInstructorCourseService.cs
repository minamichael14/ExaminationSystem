using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Instructors;

namespace ExaminationSystem.Services.InstructorStudents
{
    public interface IInstructorCourseService
    {
        void AddInstructorToCourse(int CourseID , int InstructorID);
        IQueryable<InstructorViewModel> GetInstructors(int courseID);
        IQueryable<CourseViewModel> GetCourses(int instructorID);
        void Delete(int id);

    }
}
