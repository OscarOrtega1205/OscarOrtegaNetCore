using OscarOrtegaMartinez.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OscarOrtegaMartinez.Models.Request
{
    public class TeacherCourse
    {
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
