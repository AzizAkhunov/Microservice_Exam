using MediatR;

namespace School.Application.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ParentId { get; set; }
    }
}
