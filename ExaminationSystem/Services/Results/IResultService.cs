using ExaminationSystem.ViewModels.Results;

namespace ExaminationSystem.Services.Results
{
    public interface IResultService
    {
        void Save(ResultCreateViewModel viewModel);
        ResultViewModel GetResult(int studentID, int ExamID);
    }
}
