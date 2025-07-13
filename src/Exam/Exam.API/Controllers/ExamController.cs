using Exam.Application.DTOs;
using Exam.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace Exam.API.Controllers
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

        [HttpPost("Exam")]
        [Authorize(Roles ="Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Exam([FromBody]CreateExamDto examModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            try
            {
            var createdExam = await _examsService.CreateExamAsync(examModel);
                if (createdExam == null)
                {
                    return StatusCode(500, "Failed to create exam.");
                }

                return Ok();

            }catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.Please try again later.");
            }


        }

        //[HttpGet("{id}")]
        //[Authorize]
        //[ProducesResponseType(typeof(ExamEntity), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<ExamEntity>> GetExamAsync(int id)
        //{
        //    var exam = await _examsService.GetExamAsync(id);
        //    if (exam == null)
        //        return NotFound();
        //    return Ok(exam);
        //}
     
    }
}