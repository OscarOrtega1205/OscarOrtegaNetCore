using OscarOrtegaMartinez.Models.EntityModels;
using OscarOrtegaMartinez.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OscarOrtegaMartinez.Services.Interfaces
{
    interface ICourseService
    {
        public Response Add(Course course);
        public Response Update(Course course);
        public Response Delete(Course course);
    }
}
