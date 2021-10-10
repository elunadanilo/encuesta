using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Helpers
{
    public class DbResponse
    {
        public int retcode { get; set; }
        public string mensaje { get; set; }

        public DbResponse(int retcode = 0, string mensaje = null)
        {
            this.retcode = retcode;
            this.mensaje = mensaje;
        }
    }
}
