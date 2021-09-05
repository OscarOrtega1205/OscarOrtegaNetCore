using OscarOrtegaMartinez.Models.EntityModels;
using OscarOrtegaMartinez.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OscarOrtegaMartinez.Services.Interfaces
{
    public interface ITeacherService
    {
        public Response Add(Teacher teacher);

        public Response Update(Teacher teacher);

        public Response Delete(Teacher teacher);

        public Response AssignToGroup(Teacher teacher);
    }
}
