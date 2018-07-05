using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTxtFiles
{
    class ReadTxtFiles_
    {
        public static void ReadTxtFile(string fileName)
        {
            string line;
            string strPath;
            strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(strPath+fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();

                ////check if contents of file is "true"
                //if (line == "true")
                //{
                //    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");

            }
          
        }
      
        
    }
}
