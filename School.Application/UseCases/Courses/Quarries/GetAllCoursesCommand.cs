﻿using MediatR;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.UseCases.Courses.Quarries
{
    public class GetAllCoursesCommand : IRequest<List<Course>>
    {
    }
}
