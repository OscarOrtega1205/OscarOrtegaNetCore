using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class User
    {
        public User()
        {
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
