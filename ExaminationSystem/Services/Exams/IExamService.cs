using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exams;

namespace ExaminationSystem.Services.Exams
{
    public interface IExamService
    {

        ExamViewModel getExam(int id);
        IEnumerable<ExamViewModel> GetAll();
        IEnumerable<ExamViewModel> GetCourseExams(int courseID);
        void CreateRandomQuiz(ExamRandomCreateViewModel viewModel);
        bool CreateRandomFinalExam(ExamRandomCreateViewModel viewModel);
        void CreateNormalQuiz(ExamCreateViewModel viewModel);
        bool CreateNormalFinalExam(ExamCreateViewModel viewModel);
        void DeleteExam(int id);
        void EditExamDetails(ExamEditViewModel viewModel);
        void SubmitExam(ExamSubmitViewModel viewModel);

    }
}
