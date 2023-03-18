using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Exam_Question
    {
        public int Ex_Id { get; set; }
        public Exam? Exam { get; set; }
        public int Qu_Id { get; set; }
        public Question? Question { get; set; }
    }
}
