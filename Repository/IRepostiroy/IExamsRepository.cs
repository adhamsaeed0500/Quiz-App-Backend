using Quiz_App.Models;

namespace Quiz_App.Repository.IRepostiroy
{
    public interface IExamsRepository
    {
       // public void saveExam(Exam exam);
        //public Exam GetExam(int id);
        Task<Exam> GetExamByIdAsync(int id);
        Task AddExamAsync(Exam exam);

    }
}
