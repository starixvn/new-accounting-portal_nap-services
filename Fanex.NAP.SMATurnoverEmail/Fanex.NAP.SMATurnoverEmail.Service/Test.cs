using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Fanex.NAP.SMATurnoverEmail.Service
{
    public class Test
    {
        public static void WriteTest(string message)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\LogFile.txt");
                sw.WriteLine(DateTime.Now.ToString() + ": " + message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
    }
}
