//using APCompressor;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace WFlogics
//{
//    class WFlogics_
//    {
//        private static void MonitorDirectory(string path)

//        {

//            System.IO.FileSystemWatcher fileSystemWatcher = new System.IO.FileSystemWatcher();

//            fileSystemWatcher.Path = path;

//            //fileSystemWatcher.Created += FileSystemWatcher_Created1;


//            //fileSystemWatcher.Deleted += FileSystemWatcher_Deleted1;

//            fileSystemWatcher.EnableRaisingEvents = true;

//        }


   
//        public static void FileSystemWatcher_Created1(object sender, System.IO.FileSystemEventArgs e, string input, string output, string errors, string originals)
//        {
//            string strPath = @"C:\Users\tom.bernard\Desktop\FileSystemWatcher\input";
//            string strPath2 = @"C:\Users\tom.bernard\Desktop\FileSystemWatcher\output";
//            string strPath3 = @"C:\Users\tom.bernard\Desktop\FileSystemWatcher\";

//            int j = 1;

//            string output = strPath2;

//            FindFiles.FindFiles_ ff = new FindFiles.FindFiles_.

//            //string output = customPathOut;
//            //FileInfo[] Files = FindFiles.FindFiles_.FindFiles(strPath1, ".pdf");


//            //FileInfo[] Files =  FindFiles.FindFiles_.FindFiles(strPath, ".pdf");
//            //FileInfo[] Files2 = FindFiles.FindFiles_.FindFiles(strPath3, ".pdf");
            
            

//            CompressorResult result;
//            Compressor comp = new Compressor();

//            //Compression options

//            //comp.ColorFilterLevel = 3;
//            //comp.CompressionQuality = 10;
//            //comp.ColorImageCompression = ImageCompression.Flate;
//            //comp.ColorImageFilter = ImageFilter.Lossless;
//            //comp.ColorImageLayers = 1;
//            //comp.ColorImagePrecision = ImagePrecision.Automatic;
//            //comp.CompressPDFObjects = true;
//            for (int i = 0; i < Files.Length; i++)
//            {
//                Console.WriteLine("Compressing  \n" + Files[i].ToString() + " File \n\n");
//                Console.WriteLine(string.Format("InputFile: {0}", Files[i].ToString()));
//                string outputFile = output + Files[i].ToString() + GetRandomNumber() + ".pdf";
//                Console.WriteLine(string.Format("OutputFile: {0}", outputFile));
//                result = comp.CompressPDF(strPath + "\\" + Files[i].ToString(), outputFile);
//                if (result.CompressorStatus != CompressorStatus.Success)
//                {
//                    Console.WriteLine("Compression fails with " +
//                        result.CompressorStatus.ToString() + ":" + result.Details);
//                }

//                Console.WriteLine("finished compressing file number " + j);
//                if (File.Exists(strPath3 + "\\" + Files2[i]))
//                {
//                    File.Delete(strPath3 + "\\" + Files2[i]);
//                }
//                else
//                    File.Move(strPath3 + "\\" + Files2[i], strPath2 + "\\");
//                j++;

//            }
//            Console.Write("Done");
//        }

//        internal void FileSystemWatcher_Created1(object v1, object sender, FileSystemEventArgs fileSystemEventArgs, object e, string v2, object input, string v3, object output, string v4, object errors, string v5, object originals)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
