using MediatR;

namespace School.Application.UseCases.Classrooms.Commands
{
    public class UpdateClassroomCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
    }
}
