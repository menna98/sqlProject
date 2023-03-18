using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Question
    {
        public int Qu_Id { get; set; }
        public string? Qu_Body { get; set; }
        public string? Qu_Type { get; set; }
        public string? Qu_ModelAns { get; set; }
        public int Crs_Id { get; set; }
        public virtual Course? Course { get; set; }
        public virtual ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
        public virtual ICollection<Student_Answer> Student_Answers { get; set; } = new HashSet<Student_Answer>();
        public virtual ICollection<Exam_Question> Exam_Questions { get; set; } = new HashSet<Exam_Question>();
    }
}
