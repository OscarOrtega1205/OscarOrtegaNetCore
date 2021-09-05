using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class ClassRoom
    {
        public ClassRoom()
        {
            ClassRoomCourse = new HashSet<ClassRoomCourse>();
            ClassRoomStudent = new HashSet<ClassRoomStudent>();
        }

        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ClassRoomCourse> ClassRoomCourse { get; set; }
        public virtual ICollection<ClassRoomStudent> ClassRoomStudent { get; set; }
    }
}
