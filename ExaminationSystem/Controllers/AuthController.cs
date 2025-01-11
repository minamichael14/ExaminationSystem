using ExaminationSystem.Helper;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(int id)
        {
            Role role = Role.Instructor;
            return Ok(TokenHelper.GenerateToken(id , role));
        }
    }
}
