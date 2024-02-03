using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Application.Absreaction
{
    public interface ISchoolDbContext 
    {
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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
