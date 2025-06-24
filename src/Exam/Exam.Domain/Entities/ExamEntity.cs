namespace Exam.Domain.Entities
{
    public class ExamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Puriod { get; set; }

        public List<Questions> Questions { get; set; }

    }
}
