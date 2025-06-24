using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Domain.Entities
{
    public class Questions
    {
        
        public int Id { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }

        public string choiceA { get; set; }

        public string? choiceB { get; set; } 
        public string? choiceC { get; set; } 
        public string? choiceD { get; set; } 

        public bool? IsCorrect { get; set; }
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public ExamEntity Exam { get; set; }
    }
}
