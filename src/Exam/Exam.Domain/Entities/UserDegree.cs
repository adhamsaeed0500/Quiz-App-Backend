using Account.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Domain.Entities
{
    public class UserDegree
    {
        public int Id { get; set; }
      
        public ExamEntity Exam { get; set; }
        [ForeignKey("Exam")]
        public int ExamID { get; set; }
            
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }




        public int Degree { get; set; }

    }
}
