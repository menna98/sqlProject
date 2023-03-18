using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemEF.Context;

namespace ExamSystemEF.Models
{
    public class Exam
    {
        public int Ex_Id { get; set; }
        [ForeignKey("Question")]
        public int Qu_Id { get; set; }
        public virtual Question? Question { get; set; }
        public int Student_Course_Id { get; }
        public virtual Student_Course? Student_Course { get; set; }
        public virtual ICollection<Student_Answer> Student_Answers { get; set; } = new HashSet<Student_Answer>();
    }
}
