using ExaminationSystem.ViewModels.Instructors;

namespace ExaminationSystem.Services.Instructors
{
    public interface IInstructorService
    {
        void Add(InstructorCreateViewModel viewModel);
        IEnumerable<InstructorViewModel> GetAll();
        InstructorViewModel GetByID(int id);
        void Update(int id, InstructorEditViewModel viewModel);
        void Delete(int id);
    }
}
