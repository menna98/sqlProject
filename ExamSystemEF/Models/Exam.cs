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
        public int Crs_Id { get; set; }
        public virtual Course? Course { get; set; }
        public virtual ICollection<Student_Answer> Student_Answers { get; set; } = new HashSet<Student_Answer>();
        public virtual ICollection<Exam_Question> Exam_Questions { get; set; } = new HashSet<Exam_Question>();
    }
}
