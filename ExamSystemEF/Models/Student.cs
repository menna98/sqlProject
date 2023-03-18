using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Student
    {
        public int St_Id { get; set; }
        public string? St_Fname { get; set; }
        public string St_Lname { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime St_DOB { get; set ;}
        public int Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Student_Course> Student_Courses { get; set; } = new HashSet<Student_Course>();
        public virtual ICollection<Student_Answer> Student_Answers { get; set; } = new HashSet<Student_Answer>();
    }

    
}
