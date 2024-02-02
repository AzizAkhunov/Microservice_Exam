namespace School.Domain.Entities
{
    public class ExamType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Exam Exam { get; set; }
    }
}
