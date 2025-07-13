using Exam.Application.DTOs;
using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using Exam.Infrastructure.Repositories;
using Exam.Infrastructure.Repositories.Interfaces;

namespace Exam.Application.Services
{
    public class ExamsService:IExamsService
    {
       private readonly ICreateExamAsync _examsRepository;
        public ExamsService(ICreateExamAsync createExamAsync) 
        {
            _examsRepository = createExamAsync;
        }

        public  async Task<ExamEntity> CreateExamAsync(CreateExamDto examDto)
        {
            var exam = new ExamEntity
            {
                Name = examDto.examName,
                Period = examDto.Period,
                Questions = examDto.questions.Select(q => new Questions
                {
                    Question = q.QuestionText,
                    QuestionType = q.QuestionType,
                    IsCorrect = q.IsCorrect,
                    answerA = q.answerA,
                    answerB = q.answerB,
                    answerC = q.answerC,
                    answerD = q.answerD,    
                }
                ).ToList()
            };

            await _examsRepository.CreateExamAsync( exam );
            return exam;

        }

      
    }
}
