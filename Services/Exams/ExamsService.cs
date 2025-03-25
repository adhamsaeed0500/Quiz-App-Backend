using Quiz_App.Dtos;
using Quiz_App.Repository.IRepostiroy;
using Quiz_App.Services.Exams.IExamsServices;


namespace Quiz_App.Services.Exam
{
    public class ExamsService:IExamsService
    {
        private readonly IExamsRepository _examsRepository;
        public ExamsService(IExamsRepository examsRepository) 
        {
            _examsRepository = examsRepository;
        }

        public  async Task<Quiz_App.Models.Exam> CreateExamAsync(CreateExamDto examDto)
        {
            var exam = new Quiz_App.Models.Exam
            {
                Name = examDto.examName,
                Puriod = examDto.Period,
                Questions = examDto.questions.Select(q => new Models.Questions
                {
                    Question = q.Question,
                    QuestionType = q.QuestionType.ToString(),
                    IsCorrect = q.IsCorrect,
                    choiceA = q.ChoiceA,
                    choiceB = q.ChoiceB,
                    choiceC = q.ChoiceC,
                    choiceD = q.ChoiceD,    
                }
                ).ToList()
            };

            await _examsRepository.AddExamAsync( exam );
            return exam;

        }

        public async  Task<Models.Exam> GetExamAsync(int id)
        {
          return await _examsRepository.GetExamByIdAsync( id );
        }
    }
}
