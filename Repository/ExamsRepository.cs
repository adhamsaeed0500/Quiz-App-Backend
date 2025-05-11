using Microsoft.EntityFrameworkCore;
using Quiz_App.Models;
using Quiz_App.Repository.IRepostiroy;

namespace Quiz_App.Repository
{
    public class ExamsRepository:IExamsRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public Exam GetExam(int id)
        //{
        //   return _context.Exams.Include(x => x.Questions).FirstOrDefault(x => x.Id == id);   
        //}

        //public void saveExam(Exam exam)
        //{
        //    _context.Exams.Add(exam);
        //    _context.SaveChanges();

        //}


        
        public async Task AddExamAsync(Exam exam)
        {
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
        }
      
        Task<Exam> IExamsRepository.GetExamByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
