namespace School.Api.DTOs
{
    public class StudentDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ParentId { get; set; }
    }
}
