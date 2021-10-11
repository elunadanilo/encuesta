using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Helpers
{
    public class Log
    {
        private static string pathlog = "cdn/logs/";
        public static void doLog(string texto)
        {
            DateTime currentDate = DateTime.Now;

            try
            {
                if (!Directory.Exists(pathlog))
                    Directory.CreateDirectory(pathlog);

                string Mensaje = $"{currentDate.ToString("dd/MM/yyyy HH:mm:ss.fff")} {texto}";
                string Fdate = currentDate.ToString("ddMMyyyy");
                string Fhour = currentDate.ToString("HH");

                string fileName = $"{pathlog}(ccklog){Fdate}{Fhour}.txt";

                StreamWriter writer = new StreamWriter(fileName, true);

                writer.WriteLine(Mensaje);
                writer.Close();
                writer.Dispose();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }
        }
    }
}
