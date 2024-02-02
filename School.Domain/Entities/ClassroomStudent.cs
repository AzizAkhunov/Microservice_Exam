namespace School.Domain.Entities
{
    public class ClassroomStudent
    {
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
