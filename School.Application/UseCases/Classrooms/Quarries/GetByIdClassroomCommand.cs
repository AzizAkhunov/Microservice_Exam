using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Classrooms.Quarries
{
    public class GetByIdClassroomCommand : IRequest<Classroom>
    {
        public int Id { get; set; }
    }
}
