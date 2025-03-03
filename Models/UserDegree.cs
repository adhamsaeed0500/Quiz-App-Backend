using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_App.Models
{
    public class UserDegree
    {
        public int Id { get; set; }
      
        public Exam Exam { get; set; }
        [ForeignKey("Exam")]
        public int ExamID { get; set; }
            
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }




        public int Degree { get; set; }

    }
}
