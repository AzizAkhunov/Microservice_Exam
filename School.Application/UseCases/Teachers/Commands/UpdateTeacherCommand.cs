﻿using MediatR;

namespace School.Application.UseCases.Teachers.Commands
{
    public class UpdateTeacherCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
