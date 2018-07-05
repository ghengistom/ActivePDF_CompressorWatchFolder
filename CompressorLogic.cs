using CompressorDK.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APCompressor;

namespace CompressPDFs
{
    class CompressPDFs_
    {
        public static int GetRandomNumber()
        {
            Random rnd = new Random();
            int n = rnd.Next();
            return n;
        }
        public static void CompressPDF()
        {
            string strPath1 = System.AppDomain.CurrentDomain.BaseDirectory;
            string strPath2 = System.AppDomain.CurrentDomain.BaseDirectory;
            int j = 1;

            string output = strPath1 + "output\\";

            
            FileInfo[] Files = FindFiles.FindFiles_.FindFiles(strPath1, ".pdf");

            CompressorResult result;
            Compressor comp = new Compressor();


            //Compression options

            //comp.ColorFilterLevel = 3;
            //comp.CompressionQuality = 10;
            //comp.ColorImageCompression = ImageCompression.Flate;
            //comp.ColorImageFilter = ImageFilter.Lossless;
            //comp.ColorImageLayers = 1;
            //comp.ColorImagePrecision = ImagePrecision.Automatic;
            //comp.CompressPDFObjects = true;
            for (int i = 0; i < Files.Length; i++)
            {
                Console.WriteLine("Compressing  \n" + Files[i].ToString() + " File \n\n");
                result = comp.CompressPDF(Files[i].ToString(), output + Files[i].ToString() + GetRandomNumber() + ".pdf");
                if (result.CompressorStatus != CompressorStatus.Success)
                {
                    Console.WriteLine("Compression fails with " +
                        result.CompressorStatus.ToString() + ":" + result.Details);
                }

                Console.WriteLine("finished compressing file number " + j);
                j++;

            }
            Console.Write("Done");
        }
        

       
    }
}
