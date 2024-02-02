namespace School.Domain.Entities
{
    public class Grade : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
