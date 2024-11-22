using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.StudentCourses;
using ExaminationSystem.Services.Students;
using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentCourseService _studentCourseService;
        IStudentService _studentService;

        public StudentController()
        {
            _studentCourseService = new StudentCourseService();
            _studentService = new StudentService();
        }

        [HttpGet]
        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{id}")]
        public StudentViewModel GetByID(int id)
        {
            return _studentService.GetByID(id);
        }

        [HttpPost]
        public String Create(StudentCreateViewModel viewModel)
        {
            _studentService.Create(viewModel);
            return "Done";
        }

        [HttpDelete]
        public void Delete(int id) 
        {
            _studentService.Delete(id);

        }

        [HttpPut]
        public void Update(int id, StudentEditViewModel viewModel)
        {
            _studentService.Update(id,viewModel);           
        }

        [HttpGet("Courses")]
        public IEnumerable<CourseViewModel> GetCourses(int studentID)
        {
            return _studentCourseService.GetCourses(studentID);
        }
    }
}
