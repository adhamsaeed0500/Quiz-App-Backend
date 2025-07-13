using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs
{
    public class CreateExamDto
    {
        [Required]
        [StringLength(150,MinimumLength =2)]
        public string examName { get; set; }
        [Required]
        [Range(1,600 , ErrorMessage ="the period must be more than mintue")]
        public int Period { get; set;}

       public List<QuestionsDto> questions { get; set; }
        
    }
}
