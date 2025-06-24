using Exam.Application.DTOs;
using Exam.Domain.Entities;

namespace Exam.Application.Interfaces
{
    public interface IExamsService
    {
       
        Task<ExamEntity> CreateExamAsync(CreateExamDto examDto);


    }
}
