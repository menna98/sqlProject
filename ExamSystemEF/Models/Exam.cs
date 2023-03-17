using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemEF.Context;

namespace ExamSystemEF.Models
{
    public class Exam
    {
        private IEnumerable<Question> QuestionsList = new ExamSystemContext().Questions;
        public int Ex_Id { get; set; }
        public int Ex_FullMark
        {
            get
            {
                var ExamQuestions = Student_Answers.Where(a => a.Ex_Id == Ex_Id).Select(a => a.Qu_Id);
                var QuestionMarks = QuestionsList.Where(a => ExamQuestions.Contains(a.Qu_Id)).Select(a=>a.Qu_Mark);
                int FullMark = 0;
                foreach (var Qu_Mark in QuestionMarks)
                {
                    FullMark += Qu_Mark;
                }
                return FullMark;
            }
            set { }
        }
        public int Crs_Id { get; set; }
        public virtual Course? Course { get; set; }
        public virtual ICollection<Student_Answer> Student_Answers { get; set; } = new HashSet<Student_Answer>();
        //public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
