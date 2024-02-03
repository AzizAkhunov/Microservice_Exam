using MediatR;
using School.Application.Absreaction;
using School.Application.UseCases.ExamTypes.Commands;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.ExamTypes.Handlers
{
    public class CreateExamTypeCommandHandler : IRequestHandler<CreateExamTypeCommand, bool>
    {
        private readonly ISchoolDbContext _context;

        public CreateExamTypeCommandHandler(ISchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateExamTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exam = new ExamType()
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                await _context.ExamTypes.AddAsync(exam);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
