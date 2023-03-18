using ExamSystemEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemEF.Context
{
    public class ExamSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Student_Course> Student_Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Exam_Question> Exam_Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Student_Answer> Student_Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=ExamSystemProject;trusted_connection=true;encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(config => 
            {
                config.HasKey(a => a.Dept_Id);
                config.Property(a => a.Dept_Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Student>(config => 
            { 
                config.HasKey(a => a.St_Id);
                config.Property(a => a.St_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Department).WithMany(a => a.Students).HasForeignKey(a => a.Dept_Id);
            });

            modelBuilder.Entity<Instructor>(config => 
            { 
                config.HasKey(a => a.Ins_Id);
                config.Property(a => a.Ins_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Department).WithMany(a => a.Instructors).HasForeignKey(a => a.Dept_Id);
            });

            modelBuilder.Entity<Course>(config => 
            {
                config.HasKey(a => a.Crs_Id);
                config.Property(a => a.Ins_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Instructor).WithMany(a => a.Courses).HasForeignKey(a => a.Ins_Id);
            });

            modelBuilder.Entity<Topic>(config =>
            {
                config.HasKey(a => a.Top_Id);
                config.Property(a => a.Top_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Course).WithMany(a => a.Topics).HasForeignKey(a => a.Crs_Id);
            });

            modelBuilder.Entity<Student_Course>(config =>
            {
                config.HasKey(a => new { a.St_Id, a.Crs_Id });
                config.HasOne(a => a.Student).WithMany(a => a.Student_Courses).HasForeignKey(a => a.St_Id).OnDelete(DeleteBehavior.NoAction);
                config.HasOne(a => a.Course).WithMany(a => a.Course_Students).HasForeignKey(a => a.Crs_Id).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Student_Answer>(config =>
            {
                config.HasKey(a => new { a.St_Id, a.Ex_Id, a.Qu_Id });
                config.HasOne(a => a.Student).WithMany(a => a.Student_Answers).HasForeignKey(a => a.St_Id);
                config.HasOne(a => a.Exam).WithMany(a => a.Student_Answers).HasForeignKey(a => a.Ex_Id).OnDelete(DeleteBehavior.NoAction);
                config.HasOne(a => a.Question).WithMany(a => a.Student_Answers).HasForeignKey(a => a.Qu_Id).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Question>(config => 
            {
                config.HasKey(a => a.Qu_Id);
                config.Property(a => a.Qu_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Course).WithMany(a => a.Questions).HasForeignKey(a => a.Crs_Id);
                //config.HasOne(a => a.Exam).WithMany(a => a.Questions).HasForeignKey(a => a.Ex_Id).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Choice>(config => 
            {
                config.HasKey(a => a.Ch_Id);
                config.HasOne(a => a.Question).WithMany(a => a.Choices).HasForeignKey(a => a.Qu_Id);
            });

            modelBuilder.Entity<Exam>(config => 
            { 
                config.HasKey(a => a.Ex_Id);
                config.HasOne(a => a.Course).WithMany(a => a.Exams).HasForeignKey(a => a.Crs_Id);
            });

            modelBuilder.Entity<Exam_Question>(config => 
            { 
                config.HasKey(a => new {a.Ex_Id, a.Qu_Id});
                config.HasOne(a => a.Exam).WithMany(a => a.Exam_Questions).HasForeignKey(a => a.Ex_Id).OnDelete(DeleteBehavior.NoAction);
                config.HasOne(a => a.Question).WithMany(a => a.Exam_Questions).HasForeignKey(a => a.Qu_Id).OnDelete(DeleteBehavior.NoAction);
            });

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            modelBuilder.Entity<Department>().HasData(
                    new Department { Dept_Id=1, Dept_Name="SD"},
                    new Department { Dept_Id=2, Dept_Name="UI"},
                    new Department { Dept_Id=3, Dept_Name="SW"},
                    new Department { Dept_Id=4, Dept_Name="IOT"}
                );
            
            modelBuilder.Entity<Instructor>().HasData(
                    new Instructor { Ins_Id=1, Ins_Name="Menna", Ins_Salary=9000, Dept_Id=1},
                    new Instructor { Ins_Id=2, Ins_Name="Omnia", Ins_Salary=8000, Dept_Id=1},
                    new Instructor { Ins_Id=3, Ins_Name="Aya", Ins_Salary=7000, Dept_Id=2},
                    new Instructor { Ins_Id=4, Ins_Name="Abanoub", Ins_Salary=6000, Dept_Id=2},
                    new Instructor { Ins_Id=5, Ins_Name="Mohamed", Ins_Salary=4000, Dept_Id=3},
                    new Instructor { Ins_Id=6, Ins_Name="Rami", Ins_Salary=9000, Dept_Id=3}

                );
            
            modelBuilder.Entity<Course>().HasData(
                    new Course { Crs_Id=1, Crs_Name="C#", EvaluationPercent=80, Ins_Id=5},
                    new Course { Crs_Id=2, Crs_Name="Sql", EvaluationPercent=80, Ins_Id=6},
                    new Course { Crs_Id=3, Crs_Name="Cpp", EvaluationPercent=80, Ins_Id=1},
                    new Course { Crs_Id=4, Crs_Name="MongoDB", EvaluationPercent=80, Ins_Id=1},
                    new Course { Crs_Id=5, Crs_Name="Java", EvaluationPercent=80, Ins_Id=1}

                );
            
            modelBuilder.Entity<Topic>().HasData(
                    new Topic { Top_Id=1, Topic_Name="Threading", Crs_Id=1},
                    new Topic { Top_Id=2, Topic_Name="Variables", Crs_Id=1},
                    new Topic { Top_Id=3, Topic_Name="Ado Connection", Crs_Id=1},
                    new Topic { Top_Id=4, Topic_Name="Linq", Crs_Id=1},
                    new Topic { Top_Id=5, Topic_Name="Loops", Crs_Id=1},
                    new Topic { Top_Id=6, Topic_Name="ERD", Crs_Id=2},
                    new Topic { Top_Id=7, Topic_Name="Mapping", Crs_Id=2},
                    new Topic { Top_Id=8, Topic_Name="Iterators", Crs_Id=3},
                    new Topic { Top_Id=9, Topic_Name="Inheritance", Crs_Id=3},
                    new Topic { Top_Id=10, Topic_Name="Collections", Crs_Id=4},
                    new Topic { Top_Id=11, Topic_Name="Spring", Crs_Id=5}
                );
            
            modelBuilder.Entity<Student>().HasData(
                    new Student { St_Id=1, St_Fname="Ahmed", St_Lname="Khairy", St_DOB=new DateTime(2001,5,5), Dept_Id=1},
                    new Student { St_Id=2, St_Fname="Mahmoud", St_Lname="Hesham", St_DOB=new DateTime(2000,4,4), Dept_Id=1},
                    new Student { St_Id=3, St_Fname="Mina", St_Lname="Gerges", St_DOB=new DateTime(2001,4,4), Dept_Id=1},
                    new Student { St_Id=4, St_Fname="Hossam", St_Lname="Hossam", St_DOB=new DateTime(2002,3,3), Dept_Id=1},
                    new Student { St_Id=5, St_Fname="Abdullah", St_Lname="Nagy", St_DOB=new DateTime(2004,1,1), Dept_Id=1},
                    new Student { St_Id=6, St_Fname="Mohamed", St_Lname="Abdullatif", St_DOB=new DateTime(2002,8,8), Dept_Id=1},
                    new Student { St_Id=7, St_Fname="Sara", St_Lname="Elsherif", St_DOB=new DateTime(2006,7,7), Dept_Id=1},
                    new Student { St_Id=8, St_Fname="Hellala", St_Lname="Asaad", St_DOB=new DateTime(2003,6,6), Dept_Id=1},
                    new Student { St_Id=9, St_Fname="Heba", St_Lname="Ali", St_DOB=new DateTime(2003,9,9), Dept_Id=1},
                    new Student { St_Id=10, St_Fname="Dina", St_Lname="Ahmed", St_DOB=new DateTime(2001,3,3), Dept_Id=2},
                    new Student { St_Id=11, St_Fname="Alaa", St_Lname="Mohamed", St_DOB=new DateTime(2001,5,2), Dept_Id=2},
                    new Student { St_Id=12, St_Fname="Basant", St_Lname="Reda", St_DOB=new DateTime(2001,6,6), Dept_Id=3},
                    new Student { St_Id=13, St_Fname="Yasmen", St_Lname="Alaa", St_DOB=new DateTime(2001,2,5), Dept_Id=3},
                    new Student { St_Id=14, St_Fname="Nada", St_Lname="Tamer", St_DOB=new DateTime(2001,4,5), Dept_Id=4},
                    new Student { St_Id=15, St_Fname="Habiba", St_Lname="Magdy", St_DOB=new DateTime(2001,5,3), Dept_Id=4},
                    new Student { St_Id=16, St_Fname="Yasmen", St_Lname="Magdy", St_DOB=new DateTime(2001,5,3), Dept_Id=4}
                );

            modelBuilder.Entity<Student_Course>().HasData(
                    new Student_Course { St_Id=1, Crs_Id=1},
                    new Student_Course { St_Id=1, Crs_Id=2},
                    new Student_Course { St_Id=1, Crs_Id=4},
                    new Student_Course { St_Id=2, Crs_Id=1},
                    new Student_Course { St_Id=2, Crs_Id=2},
                    new Student_Course { St_Id=2, Crs_Id=5},
                    new Student_Course { St_Id=3, Crs_Id=5},
                    new Student_Course { St_Id=3, Crs_Id=3},
                    new Student_Course { St_Id=3, Crs_Id=4},
                    new Student_Course { St_Id=11, Crs_Id=1},
                    new Student_Course { St_Id=11, Crs_Id=4},
                    new Student_Course { St_Id=11, Crs_Id=5},
                    new Student_Course { St_Id=7, Crs_Id=2},
                    new Student_Course { St_Id=7, Crs_Id=3},
                    new Student_Course { St_Id=7, Crs_Id=4},
                    new Student_Course { St_Id=8, Crs_Id=5},
                    new Student_Course { St_Id=8, Crs_Id=4},
                    new Student_Course { St_Id=8, Crs_Id=2}
                );

            //modelBuilder.Entity<Question>().HasData(
            //        new Question { Qu_Id = 1, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 2, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 3, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 4, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 5, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 6, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 7, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 8, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 9, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 10, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 11, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 12, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 13, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 14, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 15, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 16, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 17, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 18, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 19, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =},
            //        new Question { Qu_Id = 20, Qu_Body = "", Qu_Type = "", Qu_ModelAns = "", Crs_Id =}
            //    );

            //modelBuilder.Entity<Choice>().HasData(
            //        new Choice { Ch_Id=1, Ch_Body="", Qu_Id=1},
            //        new Choice { Ch_Id=2, Ch_Body="", Qu_Id=1},
            //        new Choice { Ch_Id=3, Ch_Body="", Qu_Id=1},
            //        new Choice { Ch_Id=4, Ch_Body="", Qu_Id=1},
            //    );
        }
    }
}
