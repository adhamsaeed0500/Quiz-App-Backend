using Quiz_App.Dtos;
using Quiz_App.Models;

namespace Quiz_App.Services.Exams.IExamsServices
{
    public interface IExamsService
    {
       // void CreateExam(CreateExamDto examDto);
       // public Quiz_App.Models.Exam GetExam(int id);

        Task<Quiz_App.Models.Exam> CreateExamAsync(CreateExamDto examDto);
        Task<Quiz_App.Models.Exam> GetExamAsync(int id);

    }
}
