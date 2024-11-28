using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.SubmittedAnswers;

namespace ExaminationSystem.Services.SubmittedAnswers
{
    public class SubmittedAnswerService : ISubmittedAnswerService
    {
        IRepository<SubmittedAnswer> _submitAnswerRepository;
        public SubmittedAnswerService(IRepository<SubmittedAnswer> submitAnswerRepository)
        {
            _submitAnswerRepository = submitAnswerRepository;
        }
        public void Create(SubmittedAnswerCreateViewModel viewModel)
        {
            var submittedAnswer = new SubmittedAnswer
            {
                QuestionID = viewModel.QuestionID,
                ExamID = viewModel.ExamID,
                ChoiceOrder = viewModel.Choiceorder,
                StudentID = viewModel.StudentID
            };
            _submitAnswerRepository.Add(submittedAnswer);
            _submitAnswerRepository.SaveChanges();
        }
    }
}
