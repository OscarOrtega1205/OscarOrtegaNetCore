using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class ClassRoomStudent
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int StudentId { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual Student Student { get; set; }
    }
}
