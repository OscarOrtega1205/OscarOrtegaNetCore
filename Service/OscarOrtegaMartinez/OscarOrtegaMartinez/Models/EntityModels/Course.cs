using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class Course
    {
        public Course()
        {
            ClassRoomCourse = new HashSet<ClassRoomCourse>();
            Results = new HashSet<Results>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<ClassRoomCourse> ClassRoomCourse { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
