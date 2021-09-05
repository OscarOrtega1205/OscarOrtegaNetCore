using OscarOrtegaMartinez.Models.EntityModels;
using OscarOrtegaMartinez.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OscarOrtegaMartinez.Services.Interfaces
{
    public interface IStudentService 
    {
        public Response Add(Student student);
        public Response Update(Student student);
        public Response Delete(Student student);
       
    }
}
