namespace School.Domain.Entities
{
    public class Exam : BaseModel
    {
        public int ExamTypeId { get; set; }
        public ExamType ExamType { get; set; }
        public string Name { get; set; }
        public ExamResult? ExamResult { get; set; }
    }
}
