

using Exam.Domain.Entities;
using Exam.Infrastructure.dbcontext;
using Exam.Infrastructure.Repositories.Interfaces;
using SharedResault;

namespace Exam.Infrastructure.Repositories
{
    public class ExamRepository:ICreateExamAsync
    {
        private readonly ExamDbContext _dbcontext;
        public ExamRepository(ExamDbContext examDbContext) 
        {
            _dbcontext = examDbContext;
        }

        public async Task<Result> CreateExamAsync(ExamEntity exam)
        {
            try
            {
                await _dbcontext.Exams.AddAsync(exam);
                await _dbcontext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure("Unexpected error occurred");
            }
        }


    }
}
