using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs
{
    public class CreateExamDto
    {
        [Required]
        [StringLength(150,MinimumLength =5)]
        public string examName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Period { get; set;}

       public List<QuestionsDto> questions { get; set; }
        
    }
}
