using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFiles
{
    class CreateFiles_
    {
        public static void CreateFile(string filename, string logContents)
        {
            string strPath;
            strPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\LogFolder";


            string path = @strPath+filename;
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (System.IO.StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(logContents);
                   
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
