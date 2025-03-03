namespace Quiz_App.Models
{
    public class Questions
    {

        public Exam Exam { get; set; }

        public string Question { get; set; }

        public bool? IsCorrect { get; set; }
    }
}
