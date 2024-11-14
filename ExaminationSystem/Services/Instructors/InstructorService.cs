using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Instructors;

namespace ExaminationSystem.Services.Instructors
{
    public class InstructorService:IInstructorService
    {
        IRepository<Instructor> _instructorRepository;
        public InstructorService()
        {
            _instructorRepository = new Repository<Instructor>();
        }
        public void Add(InstructorCreateViewModel viewModel)
        {
            var instructor = viewModel.ToModel();
            _instructorRepository.Add(instructor);
            _instructorRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var instructor = new Instructor { ID = id };

            _instructorRepository.Delete(instructor);

            _instructorRepository.SaveChanges();
        }

        public IEnumerable<InstructorViewModel> GetAll()
        {
            return _instructorRepository.Get().ToViewModel();
        }

        public InstructorViewModel GetByID(int id)
        {
            var instructor =
                _instructorRepository.Get().Where(x => x.ID == id)
                .ToViewModel().FirstOrDefault();

            return instructor;
        }

        public void Update(int id, InstructorEditViewModel viewModel)
        {
            viewModel.ID = id;
            var instructor = viewModel.ToModel();
            _instructorRepository.SaveInclude(instructor, nameof(instructor.Name), nameof(instructor.Phone));
            _instructorRepository.SaveChanges();
        }
    }
}
