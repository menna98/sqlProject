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
        public int Ch_Id { get; set; }
        public string? Ch_Body { get; set; }
        public int Qu_Id { get; set; }
        public virtual Question? Question { get; set; }
    }
}
