using ExaminationSystem.Services.Answers;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.ViewModels.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestoionService _questionService;
        IAnswerService _answerService;
        IChoiceService _choiceService;
        public QuestionController()
        {
            _questionService = new QuestionService();
            _answerService = new AnswerService();
            _choiceService = new ChoiceService();
        }

        [HttpPost]
        public void Create(QuestionCreateViewModel viewModel)
        {
            _questionService.Add( viewModel );
            //_answerService.Add(viewModel.answer);
            //foreach (var choice in viewModel.Choices)
            //{
            //    _choiceService.Add(choice);
            //}
        }
    }
}
