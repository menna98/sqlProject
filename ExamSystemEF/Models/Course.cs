using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Course
    {
        public int Crs_Id { get; set; }
        public string Crs_Name { get; set; } = null!;
        public int EvaluationPercent { get; set; }
        public int Ins_Id { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public virtual ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();
        public virtual ICollection<Student_Course> Course_Students { get; set; } = new HashSet<Student_Course>();
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public virtual ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
    }
}
