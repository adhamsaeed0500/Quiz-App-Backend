using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Quiz_App.Dtos;
using Quiz_App.Models;
using Quiz_App.Services.Exams.IExamsServices;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Authorize(Roles ="Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Exams([FromBody]CreateExamDto examModel)
        {          
            try
            {
            var createdExam = await _examsService.CreateExamAsync(examModel);
                if (createdExam == null)
                {
                    return StatusCode(500, "Failed to create exam.");
                }

                return CreatedAtAction(nameof(GetExamAsync), new { id = createdExam.Id }, createdExam);

            }catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.Please try again later.");
            }


        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Exam), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Exam>> GetExamAsync(int id)
        {
            var exam = await _examsService.GetExamAsync(id);
            if (exam == null)
                return NotFound();
            return Ok(exam);
        }
     
    }
}