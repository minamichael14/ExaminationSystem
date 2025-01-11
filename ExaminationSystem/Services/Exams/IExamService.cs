using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exams;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {
        ExamViewModel GetExam(int id);
        IEnumerable<ExamViewModel> GetAll();
        IEnumerable<ExamViewModel> GetCourseExams(int courseID);
        bool CreateRandomQuiz(ExamCreateViewModel viewModel);
        bool CreateRandomFinalExam(ExamCreateViewModel viewModel);
        bool CreateNormalQuiz(ExamCreateViewModel viewModel);
        bool CreateNormalFinalExam(ExamCreateViewModel viewModel);
        bool DeleteExam(int id);
        bool EditExamDetails(ExamEditViewModel viewModel);
        void SubmitExam(ExamSubmitViewModel viewModel);

    }
}
