using ExaminationSystem.Filters;
using ExaminationSystem.Models.Enums;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.ViewModels.Exams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        
        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(CustomizeAuthorizeAttribute),Arguments = new object[] {Feature.GetAllExams})]
        public IEnumerable<ExamViewModel> GetAll()
        {
            return _examService.GetAll();
        }

        [HttpGet("Course")]
        public IEnumerable<ExamViewModel> GetAllByCourse(int courseID)
        {
            return _examService.GetCourseExams(courseID);
        }

        [HttpPost("Create-Final-Exam")]
        public IActionResult CreateFinalExam(ExamCreateViewModel viewModel)
        {
            if (_examService.CreateNormalFinalExam(viewModel))
            {
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Create-Random-Final-Exam")]
        public IActionResult CreateRandomFinalExam(ExamCreateViewModel viewModel)
        {
            if(_examService.CreateRandomFinalExam(viewModel))
            {
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Create-Quiz")]
        public IActionResult CreateQuiz(ExamCreateViewModel viewModel)
        {
            if(_examService.CreateNormalQuiz(viewModel))
            {
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Create-Random-Quiz")]
        public IActionResult CreateRandomQuiz(ExamCreateViewModel viewModel)
        {
            if(_examService.CreateRandomQuiz(viewModel))
            {
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int examID) 
        {
            if(_examService.DeleteExam(examID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(ExamEditViewModel viewModel)
        {
            if(_examService.EditExamDetails(viewModel))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Submit")]
        public void Submit(ExamSubmitViewModel viewModel)
        {
            _examService.SubmitExam(viewModel);
        }
    }
}
