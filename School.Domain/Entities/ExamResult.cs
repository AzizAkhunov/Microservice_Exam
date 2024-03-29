﻿namespace School.Domain.Entities
{
    public class ExamResult : BaseModel
    {
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Marks { get; set; }
    }
}
