using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Choice
    {
        public string? Qu_Choice { get; set; }
        public int Qu_Id { get; set; }
        public virtual Question? Question { get; set; }
    }
}
