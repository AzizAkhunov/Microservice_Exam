using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Student : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}
