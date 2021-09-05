using System;
using System.Collections.Generic;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class Results
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string CourseName { get; set; }
        public string Marks { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
