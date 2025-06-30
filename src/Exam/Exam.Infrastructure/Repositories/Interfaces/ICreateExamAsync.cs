using Exam.Domain.Entities;
using Return;

namespace Exam.Infrastructure.Repositories.Interfaces
{
    public interface ICreateExamAsync
    {
        Task<Result> CreateExamAsync(ExamEntity examEntity);
    }
}
