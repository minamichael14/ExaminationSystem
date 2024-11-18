using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.StudentCourses;
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
        IRepository<Student> _studentRepository;
        IStudentCourseService _studentCourseService;

        public StudentController()
        {
            _studentRepository = new Repository<Student>();
            _studentCourseService = new StudentCourseService();
        }

        [HttpGet]
        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentRepository.Get().ToViewModel();
        }

        [HttpGet("{id}")]
        public StudentViewModel GetByID(int id)
        {
            return _studentRepository.Get().Where(x => x.ID == id)
                .ToViewModel().FirstOrDefault();
        }

        [HttpPost]
        public String Create(StudentCreateViewModel viewModel)
        {
            _studentRepository.Add(viewModel.ToModel());
            _studentRepository.SaveChanges();
            return "Done";
        }

        [HttpDelete]
        public void Delete(int id) 
        {
            var student = new Student { ID = id };
            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();

        }

        [HttpPut]
        public void Update(int id, StudentEditViewModel viewModel)
        {
            viewModel.ID = id;
            var student = viewModel.ToModel();
            _studentRepository.SaveInclude(
                student,
                nameof(student.Name),
                nameof(student.Grade),
                nameof(student.Phone),
                nameof(student.Age)
                );
            _studentRepository.SaveChanges();
        }

        [HttpGet("Courses")]
        public IEnumerable<CourseViewModel> GetCourses(int studentID)
        {
            return _studentCourseService.GetCourses(studentID);
        }
    }
}
