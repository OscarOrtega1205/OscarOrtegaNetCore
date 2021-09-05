using OscarOrtegaMartinez.Models.Request;
using OscarOrtegaMartinez.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OscarOrtegaMartinez.Services.Interfaces
{
    public interface IUserService
    {
        public Response Auth(AuthRequest authRequest);
    }
}
