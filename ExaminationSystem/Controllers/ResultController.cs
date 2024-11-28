using ExaminationSystem.Models;
using ExaminationSystem.Services.Results;
using ExaminationSystem.ViewModels.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet]
        public ResultViewModel Get(int studentID, int examID)
        {
            return _resultService.GetResult(studentID, examID);
        }
        
        

        
    }
}
