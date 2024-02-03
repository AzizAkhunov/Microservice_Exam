namespace School.Api.DTOs
{
    public class AttendanceDTO 
    {
        public string Date { get; set; }
        public int StudentId { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; } 
    }
}
