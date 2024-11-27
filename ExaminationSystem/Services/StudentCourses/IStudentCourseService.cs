using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Students;

namespace ExaminationSystem.Services.StudentCourses
{
    public interface IStudentCourseService
    {
        void EnrollStudentInCourse(int courseID, int studentID , int instructorID);

        IQueryable<StudentViewModel> GetStudents(int courseID);
        IQueryable<CourseViewModel> GetCourses(int StudentID);

    }
}
