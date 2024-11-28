using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Results;

namespace ExaminationSystem.Services.Results
{
    public class ResultService : IResultService
    {
        IRepository<Result> _resultRepository;

        public ResultService(IRepository<Result> repository)
        {
            _resultRepository = repository;
        }
        public ResultViewModel GetResult(int studentID, int ExamID)
        {
            var result = _resultRepository.Get()
                            .Where(x => 
                                    x.StudentID == studentID 
                                    && x.ExamID == ExamID)
                            .ToViewModel()
                            .FirstOrDefault();
            return result;
        }

        public void Save(ResultCreateViewModel viewModel)
        {
            var result = new Result
            {
                StudentID = viewModel.StudentID,
                ExamID = viewModel.ExamID,
                Value = viewModel.value
            };
            _resultRepository.Add(result);
            _resultRepository.SaveChanges();
        }
    }
}
