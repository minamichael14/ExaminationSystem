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
        public QuestionController(IQuestoionService questionService)
        {
            _questionService = questionService;

        }

        [HttpPost]
        public void Create(QuestionCreateViewModel questionViewModel)
        {
            _questionService.Add( questionViewModel );
        }

        [HttpGet]
        public IEnumerable<QuestionViewModel> Get()
        {
            return _questionService.GetAll();
        }


        [HttpGet("{id}")]
        public QuestionViewModel GetByID(int id)
        {
            return _questionService.GetById(id);
        }

        [HttpDelete]
        public void Delete(int questionID)
        {
            _questionService.Delete(questionID);
        }

        [HttpPut]
        public void Update(QuestionEditViewModel questionViewModel)
        {
            _questionService.Update(questionViewModel);
        }


    }
}
