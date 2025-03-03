namespace Quiz_App.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Puriod { get; set; }

        public List<Questions> Questions { get;}

    }
}
