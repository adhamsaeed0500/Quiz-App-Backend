using Exam.Domain.Entities;
using SharedResault;

namespace Exam.Infrastructure.Repositories.Interfaces
{
    public interface ICreateExamAsync
    {
        Task<Result> CreateExamAsync(ExamEntity examEntity);
    }
}
