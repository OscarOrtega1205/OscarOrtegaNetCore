using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
