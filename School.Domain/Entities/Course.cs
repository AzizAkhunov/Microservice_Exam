namespace School.Domain.Entities
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }    
    }
}
