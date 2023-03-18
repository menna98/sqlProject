using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Student_Course
    {
        public int St_Id { get; set; }
        public virtual Student? Student { get; set; }
        public int Crs_Id { get; set; }
        public virtual Course? Course { get; set; }
        public int Ex_Id { get; set; }
        [ForeignKey("Ex_Id,Qu_Id")]
        public virtual Exam? Exam { get; set; }
        public int Qu_Id { get; }
        public virtual Question? Question { get; set; }
        
        public int? grade { get; set; }
    }
}
