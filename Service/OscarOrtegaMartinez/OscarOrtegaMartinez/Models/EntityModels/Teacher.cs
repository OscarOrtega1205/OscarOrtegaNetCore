using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class Teacher
    {
        public Teacher()
        {
            ClassRoom = new HashSet<ClassRoom>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ClassRoom> ClassRoom { get; set; }
    }
}
