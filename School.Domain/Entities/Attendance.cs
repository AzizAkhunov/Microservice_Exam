namespace School.Domain.Entities
{
    public class Attendance
    {
        public string Date { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
