using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Student_Answer
    {
        public int St_Id { get; set; }
        public int Ex_Id { get; set; }
        public int Qu_Id { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Exam? Exam { get; set; }
        public virtual Question? Question { get; set; }
        public string? St_Ans { get; set; }
        public int? St_Grade { get; set; }
    }
}
