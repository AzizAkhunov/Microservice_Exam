using MediatR;

namespace School.Application.UseCases.Classrooms.Commands
{
    public class CreateClassroomCommand : IRequest<bool>
    {
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
    }
}
