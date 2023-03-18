using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Instructor
    {
        public int Ins_Id { get; set; }
        public string Ins_Name { get; set; } = null!;
        public int Ins_Salary { get; set; }
        public int Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
