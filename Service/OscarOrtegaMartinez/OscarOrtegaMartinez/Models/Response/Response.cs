using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OscarOrtegaMartinez.Models.Response
{
    public class Response
    {
        public bool Success { get; set; }
        public Object Data { get; set; }
        public string Message { get; set; }
    }
}
