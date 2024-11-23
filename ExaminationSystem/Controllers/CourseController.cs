using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.InstructorStudents;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.Services.StudentCourses;
using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Instructors;
using ExaminationSystem.ViewModels.Questions;
using ExaminationSystem.ViewModels.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;
        IInstructorCourseService _instructorCourseService;
        IStudentCourseService _studentCourseService;
        IInstructorStudentService _instructorStudentService;
        IQuestoionService _questoionService;
        public CourseController( IQuestoionService questoionService)
        {
            _courseService = new CourseService();
            _instructorCourseService = new InstructorCourseService();
            _studentCourseService = new StudentCourseService();
            _instructorStudentService = new InstructorStudentService();
            _questoionService = questoionService;
        }

        //CreateCourse: Instructor create course
        [HttpPost]
        public String Create(CourseCreateViewModel courseViewModel)
        {

            var courseID = _courseService.Create(courseViewModel);
            _instructorCourseService.AddInstructorToCourse(courseID, courseViewModel.InstrucorID);
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


        [HttpGet("Question")]
        public IEnumerable<QuestionViewModel> GetQuestion(int CourseID)
        {
            return _questoionService.GetByCourse(CourseID);
        }


        // DeleteCourse
        [HttpDelete]
        public void Delete(int CourseID)
        {
            _courseService.Delete(CourseID);
        }

        // EditCourse
        [HttpPut]
        public void Update(CourseEditViewModel viewModel)
        {
            _courseService.Update(viewModel);
        }

        [HttpGet]
        public IEnumerable<CourseViewModel> GetAll()
        {
            return _courseService.GetAll();
        }
    }
}
