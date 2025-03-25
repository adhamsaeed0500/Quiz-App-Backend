using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_App.Dtos;
using Quiz_App.Models;
using Quiz_App.Services.Exams.IExamsServices;

namespace Quiz_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        public readonly IExamsService _examsService;
        public ExamController(IExamsService examsService)
        {
            _examsService = examsService;
        }

        [HttpPost("Exams")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Exams(CreateExamDto examModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdExam = await _examsService.CreateExamAsync(examModel);

            return Ok(nameof(createdExam));

        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Exam), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _examsService.GetExamAsync(id);
            return Ok(exam);
        }

    }
}
