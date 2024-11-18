using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.InstructorStudents;
using ExaminationSystem.Services.StudentCourses;
using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Instructors;
using ExaminationSystem.ViewModels.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        
        //- DeleteCourse
        //- EditCourse
        //- GetCourse
        //- GetCourseByID

        IRepository<Course> _courserepository;
        IInstructorCourseService _instructorCourseService;
        IStudentCourseService _studentCourseService;
        IInstructorStudentService _instructorStudentService;
        public CourseController()
        {
            _courserepository = new Repository<Course>();
            _instructorCourseService = new InstructorCourseService();
            _studentCourseService = new StudentCourseService();
            _instructorStudentService = new InstructorStudentService();
        }

        //CreateCourse: Instructor create course
        [HttpPost]
        public String Create(CourseCreateViewModel courseViewModel)
        {
            var course = courseViewModel.ToModel();
            _courserepository.Add(course);
            _courserepository.SaveChanges();
            _instructorCourseService.AddInstructorToCourse(course.ID, courseViewModel.InstrucorID);
            return "Done";
        }
        
        
        [HttpPost("AddInstructor")]
        public void AddInstructor(int courseID, int instructorID)
        {
            _instructorCourseService.AddInstructorToCourse(courseID, instructorID);
        }

        // EnrollStudent
        [HttpPost("EnrollStudent")]
        public void EnrollStudent(int studentID , int courseID, int instructorID)
        {
            _instructorStudentService.EnrollStudentByInstructor(studentID, instructorID);
            _studentCourseService.EnrollStudentInCourse(courseID, studentID);
        }


     
        [HttpGet("Instructor")]
        public IEnumerable<InstructorViewModel> GetInstructors(int CourseID)
        {
            return _instructorCourseService.GetInstructors(CourseID);
        }

        [HttpGet("Student")]
        public IEnumerable<StudentViewModel> GetStudents(int CourseID)
        {
            return _studentCourseService.GetStudents(CourseID);

        }


        // DeleteCourse
        [HttpDelete]
        public void Delete(int CourseID)
        {
            var course = new Course { ID = CourseID };
            _courserepository.Delete(course);
            _courserepository.SaveChanges();
        }

        // EditCourse
        [HttpPut]
        public void Update(CourseEditViewModel viewModel)
        {
            var course = viewModel.ToModel();
            _courserepository.SaveInclude(course, nameof(course.Name), nameof(course.Description), nameof(course.Hours));
            _courserepository.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<CourseViewModel> GetAll()
        {
            return _courserepository.Get().ToViewModel();
        }
    }
}
