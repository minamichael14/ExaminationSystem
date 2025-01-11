using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Students;

namespace ExaminationSystem.Services.Students
{
    public interface IStudentService
    {
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetByID(int id);
        void Create(StudentCreateViewModel viewModel);
        void Delete(int id);
        void Update(int id, StudentEditViewModel viewModel);
    }
}
