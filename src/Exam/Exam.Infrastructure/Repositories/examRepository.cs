

using Exam.Domain.Entities;
using Exam.Infrastructure.dbcontext;
using Exam.Infrastructure.Repositories.Interfaces;

namespace Exam.Infrastructure.Repositories
{
    public class ExamRepository:ICreateExamAsync
    {
        private readonly ExamDbContext _dbcontext;
        public ExamRepository(ExamDbContext examDbContext) 
        {
            _dbcontext = examDbContext;
        }

        public async Task<string> CreateExamAsync(ExamEntity exam)
        {
            try
            {
                await _dbcontext.Exams.AddAsync(exam);
                await _dbcontext.SaveChangesAsync();
                return "Exam created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
