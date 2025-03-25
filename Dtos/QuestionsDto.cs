using Quiz_App.enums;
using System.ComponentModel.DataAnnotations;

namespace Quiz_App.Dtos
{
    public class QuestionsDto
    {

        [Required]
        [StringLength(150,MinimumLength = 5)]
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public string ChoiceA { get; set; }
        public string? ChoiceB { get; set; }
        public string? ChoiceC { get; set; }
        public string? ChoiceD { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
