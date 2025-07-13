using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Domain.Entities
{
    public class Questions
    {
        
        public int Id { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }

        public string answerA { get; set; }

        public string? answerB { get; set; } 
        public string? answerC { get; set; } 
        public string? answerD { get; set; } 

        public string IsCorrect { get; set; }
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public ExamEntity Exam { get; set; }
    }
}
