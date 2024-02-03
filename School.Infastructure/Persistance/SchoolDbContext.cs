using Microsoft.EntityFrameworkCore;
using School.Application.Absreaction;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infastructure.Persistance
{
    public class SchoolDbContext : DbContext , ISchoolDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
           : base(options)
           => Database.Migrate();

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassroomStudent> ClassroomStudents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>()
                .HasMany(x => x.Childs)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId)
                .IsRequired();


            modelBuilder.Entity<Student>()
                .HasMany(x => x.Classrooms)
                .WithMany(x => x.Students)
                .UsingEntity(typeof(ClassroomStudent));

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Attendances)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasMany(x => x.ExamResults)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            modelBuilder.Entity<Grade>()
                .HasMany(x => x.Classrooms)
                .WithOne(x => x.Grade)
                .HasForeignKey(x => x.GradeId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.Classroom)
                .WithOne(x => x.Teacher)
                .HasForeignKey<Classroom>(x => x.TeacherId)
                .IsRequired();

            modelBuilder.Entity<Grade>()
                .HasMany(x => x.Courses)
                .WithOne(x => x.Grade)
                .HasForeignKey(g => g.GradeId)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .HasMany(x => x.ExamResults)
                .WithOne(x => x.Course)
                .HasForeignKey (g => g.CourseId)
                .IsRequired();

            modelBuilder.Entity<Exam>()
                .HasOne(x => x.ExamType)
                .WithOne(x => x.Exam)
                .HasForeignKey<Exam>(x => x.ExamTypeId)
                .IsRequired();

            modelBuilder.Entity<Exam>()
                .HasOne(x => x.ExamResult)
                .WithOne(x => x.Exam)
                .HasForeignKey<ExamResult>(x => x.ExamId)
                .IsRequired();

        }

    }
}
