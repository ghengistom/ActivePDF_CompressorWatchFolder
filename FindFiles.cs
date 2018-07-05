using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFiles
{
    class FindFiles_
    {
        public static FileInfo[] FindFiles(string strPath, string filetype)
        {
            string str = "";

            //Find docx files 
            System.IO.DirectoryInfo d = new DirectoryInfo(@strPath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*" + filetype); //Getting Text files
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }
            return Files;
        }

    }
}
