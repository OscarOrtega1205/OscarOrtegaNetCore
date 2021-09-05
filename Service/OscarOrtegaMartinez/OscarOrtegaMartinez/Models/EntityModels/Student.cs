using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class Student
    {
        public Student()
        {
            ClassRoomStudent = new HashSet<ClassRoomStudent>();
            Results = new HashSet<Results>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ControlNumber { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ClassRoomStudent> ClassRoomStudent { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
