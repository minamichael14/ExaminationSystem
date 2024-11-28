using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels.Exams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpGet]
        public IEnumerable<ExamViewModel> GetAll()
        {
            return _examService.GetAll();
        }

        [HttpGet("Course")]
        public IEnumerable<ExamViewModel> GetAllByCourse(int courseID)
        {
            return _examService.GetCourseExams(courseID);
        }

        [HttpPost("CreateFinalExam")]
        public void CreateFinalExam(ExamCreateViewModel viewModel)
        {
           _examService.CreateNormalFinalExam(viewModel);
        }

        [HttpPost("CreateRandomFinalExam")]
        public void CreateRandomFinalExam(ExamRandomCreateViewModel viewModel)
        {
            _examService.CreateRandomFinalExam(viewModel);
        }

        [HttpPost("CreateQuiz")]
        public void CreateQuiz(ExamCreateViewModel viewModel)
        {
            _examService.CreateNormalQuiz(viewModel);
        }

        [HttpPost("CreateRandomQuiz")]
        public void CreateRandomQuiz(ExamRandomCreateViewModel viewModel)
        {
            _examService.CreateRandomQuiz(viewModel);
        }

        [HttpDelete]
        public void Delete(int examID) 
        {
            _examService.DeleteExam(examID);
        }

        [HttpPut]
        public void Update(ExamEditViewModel viewModel)
        {
            _examService.EditExamDetails(viewModel);
        }

        [HttpPost("Submit")]
        public void Submit(ExamSubmitViewModel viewModel)
        {
            _examService.SubmitExam(viewModel);
        }
    }
}
