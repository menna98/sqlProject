using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Department
    {
        public int Dept_Id { get; set; }
        public string? Dept_Name { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}
