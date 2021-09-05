using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class ClassRoomCourse
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int CourseId { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual Course Course { get; set; }
    }
}
