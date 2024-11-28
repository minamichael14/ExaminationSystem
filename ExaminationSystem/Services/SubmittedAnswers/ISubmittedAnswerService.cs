using ExaminationSystem.ViewModels.SubmittedAnswers;

namespace ExaminationSystem.Services.SubmittedAnswers
{
    public interface ISubmittedAnswerService
    {
        void Create(SubmittedAnswerCreateViewModel viewModel);
    }
}
