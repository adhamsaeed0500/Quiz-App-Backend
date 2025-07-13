using Exam.Application.enums;
using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs
{
    public class QuestionsDto
    {

        [Required]
        [StringLength(150,MinimumLength = 5)]
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string answerA { get; set; }
        public string? answerB { get; set; }
        public string? answerC { get; set; }
        public string? answerD { get; set; }
        public string IsCorrect { get; set; }
    }
}
