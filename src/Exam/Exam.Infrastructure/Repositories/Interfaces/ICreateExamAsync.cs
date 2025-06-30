using Exam.Domain.Entities;

namespace Exam.Infrastructure.Repositories.Interfaces
{
    public interface ICreateExamAsync
    {
        Task<string> CreateExamAsync(ExamEntity examEntity);
    }
}
