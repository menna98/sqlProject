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
                config.Ignore(a => a.St_Age);
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
                config.HasOne(a => a.Student).WithMany(a => a.Student_Courses).HasForeignKey(a => a.St_Id);
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
                //config.Ignore(a => a.Ex_Id);
                config.HasKey(a => a.Qu_Id);
                config.Property(a => a.Qu_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Course).WithMany(a => a.Questions).HasForeignKey(a => a.Crs_Id);
                //config.HasOne(a => a.Exam).WithMany(a => a.Questions).HasForeignKey(a => a.Ex_Id).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Choice>(config => 
            {
                config.HasKey(a => new { a.Qu_Id, a.Qu_Choice });
                config.HasOne(a => a.Question).WithMany(a => a.Choices).HasForeignKey(a => a.Qu_Id);
            });

            modelBuilder.Entity<Exam>(config => 
            { 
                config.HasKey(a => a.Ex_Id);
                config.Property(a => a.Ex_Id).ValueGeneratedOnAdd();
                config.HasOne(a => a.Course).WithMany(a => a.Exams).HasForeignKey(a => a.Crs_Id);
            });
        }
    }
}
