using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Models
{
    public class Topic
    {
        public int Top_Id { get; set; }
        public string? Topic_Name { get; set; }
        public int Crs_Id { get; set; }
        public virtual Course? Course { get; set; }
    }
}
