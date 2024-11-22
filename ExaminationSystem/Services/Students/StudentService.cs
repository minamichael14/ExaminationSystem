using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.StudentCourses;
using ExaminationSystem.ViewModels.Students;

namespace ExaminationSystem.Services.Students
{
    public class StudentService : IStudentService
    {
        IRepository<Student> _studentRepository;

        public StudentService()
        {
            _studentRepository = new Repository<Student>();
        }

        public void Create(StudentCreateViewModel viewModel)
        {
            _studentRepository.Add(viewModel.ToModel());
            _studentRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = new Student { ID = id };
            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentRepository.Get().ToViewModel();
        }

        public StudentViewModel GetByID(int id)
        {
            return _studentRepository.Get().Where(x => x.ID == id)
                .ToViewModel().FirstOrDefault();
        }

        public void Update(int id, StudentEditViewModel viewModel)
        {
            // TODO
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
    }
}
