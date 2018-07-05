using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APCompressor;
using CompressorDK.Results;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace NET_app
{
    
    public class CompressorSettings
    {
        public short CompressionQuality;
        public string ColorImageCompression;
        public string ColorImageFilter;
        public short ColorImageLayers;
        public string ColorImagePrecision;
        public bool CompressPDFObjects;
    }
    class Program
    {
        //For the watchfolder 
        private static void MonitorDirectory(string path)

        {
            System.IO.FileSystemWatcher fileSystemWatcher = new System.IO.FileSystemWatcher();

            fileSystemWatcher.Path = path;

            fileSystemWatcher.Created += FileSystemWatcher_Created1;

            fileSystemWatcher.EnableRaisingEvents = true;

        }
     
        //==========WF logic==========================================================================================//
        private static void FileSystemWatcher_Created1(object sender, System.IO.FileSystemEventArgs e)
        {
            
            string mainFolder;
            string input;
            string output;
            string errors;
            string original;

            //It will apply these settings for each file that gets compressed through the WF
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;


            //Read Settings File=============================================================================//
            //JObject o1 = JObject.Parse(File.ReadAllText(strPath + "CompressorSettings.json"));

            // read JSON directly from a file
            //using (StreamReader file = File.OpenText(strPath + "CompressorSettings.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    // Console.WriteLine("This is the jsontext" + o1.ToString());
            //    //JObject[] jsonValue = new JObject[5];
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);

            //    foreach (KeyValuePair<string, JToken> pair in o2)
            //    {
            //        //Console.WriteLine(pair["CompressionQuality"].Type);
            //        Console.WriteLine(pair.Value);

            //    }

            //}


            //Get the current user directory
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            //Instantiate Compressor Object
            CompressorResult result;
            Compressor comp = new Compressor();


            //=====Check for the Compressor Settings file if it exists then use these settings below  =======//
            //Do the compressor settings file
            string json = strPath + "CompressorSettings.json";
            if(File.Exists(json))
            {
                Debug.Assert(File.Exists(json));
                // CompressorSettings settings = JsonConvert.DeserializeObject<CompressorSettings>();
                CompressorSettings settings = JsonConvert.DeserializeObject<CompressorSettings>(File.ReadAllText(json));

                short compressionQuality = settings.CompressionQuality;
                string colorImageCompression = settings.ColorImageCompression;
                string colorImageFilter = settings.ColorImageFilter;
                short colorImageLayers = settings.ColorImageLayers;
                string colorImagePrecision = settings.ColorImagePrecision;
                bool compressPDFobjects = settings.CompressPDFObjects;

                //Compression options

                //comp.ColorFilterLevel = 3;
                comp.CompressionQuality = compressionQuality;

                if(colorImageCompression.ToLower() == "flate")
                {
                    comp.ColorImageCompression = ImageCompression.Flate;
                }
                else if(colorImageCompression.ToLower() == "jbig")
                {
                    comp.ColorImageCompression = ImageCompression.JBig;
                }
                else if(colorImageCompression.ToLower() == "jp2")
                {
                    comp.ColorImageCompression = ImageCompression.JP2;
                }
                else if (colorImageCompression.ToLower() == "retainexisting")
                {
                    comp.ColorImageCompression = ImageCompression.RetainExisting;
                }


                if(colorImageCompression.ToLower() == "lossless")
                {
                    comp.ColorImageFilter = ImageFilter.Lossless;
                }
                else if(colorImageCompression.ToLower() == "lossy")
                {
                    comp.ColorImageFilter = ImageFilter.Lossy;
                }
                

                comp.ColorImageLayers = colorImageLayers;


                if(colorImageCompression.ToLower() == "automatic")
                {
                    comp.ColorImagePrecision = ImagePrecision.Automatic;
                }
                else if(colorImageCompression.ToLower() == "sixteen")
                {
                    comp.ColorImagePrecision = ImagePrecision.Sixteen;
                }
                else if(colorImageCompression.ToLower() == "thirtytwo")
                {
                    comp.ColorImagePrecision = ImagePrecision.ThirtyTwo;
                }
                

                comp.CompressPDFObjects = compressPDFobjects;

                //===============Configure Compressor Settings if provided json file========================//
            }


            //Set variables to Watch Folder path 
            mainFolder = path + "\\Desktop\\Compressor WatchFolder";
            input = mainFolder + "\\Input";
            output = mainFolder + "\\Output";
            errors = mainFolder + "\\Errors";
            original = mainFolder + "\\original";

            int j = 1;

            FileInfo[] Files = FindFiles.FindFiles_.FindFiles(input + "\\", ".pdf");


            for (int i = 0; i < Files.Length; i++)
            {
                Console.WriteLine("Input file path = " + input + " Output file path " + output);
                Console.WriteLine("Compressing  \n" + Files[i].ToString() + " File \n\n");
                result = comp.CompressPDF(input + "\\" + Files[i].ToString(), output + "\\" + Files[i].ToString());     //convert file and send to output folder
                if (result.CompressorStatus == CompressorStatus.Success)
                {
                    MoveFiles.MoveFiles_.MoveFile(input + "\\" + Files[i], original + "\\" + Files[i]);                //if success move to originals
                }
                else if (result.CompressorStatus != CompressorStatus.Success)
                {
                    Console.WriteLine("Compression fails with " + result.CompressorStatus.ToString() + ":" + result.Details);
                    string logContents = result.CompressorStatus.ToString() + " : " + result.Details;
                    MoveFiles.MoveFiles_.MoveFile(input + "\\" + Files[i], errors + "\\" + Files[i]);                   //if fails move to errors folder

                    //Test Log component
                    LogWriter.LogWriter_ lw = new LogWriter.LogWriter_();
                    lw.LogWrite(logContents, Files[i].ToString());

                }

                Console.WriteLine("finished compressing file number " + j);
                j++;

            }

        }
        //==========WF logic==========================================================================================// 

        static void Main(string[] args)
        {
                       
            //==========Setup WF Folders==========================================================================================//
            string mainFolder;
            string input;
            string output;
            string errors;
            string original;

            
            //Get the current user directory
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            //Setup Watch Folder Infrastructure
            mainFolder = path + "\\Desktop\\Compressor WatchFolder";
            input = mainFolder + "\\Input";
            output = mainFolder + "\\Output";
            errors = mainFolder + "\\Errors";
            original = mainFolder + "\\original";

            CreateDirectories.CreateDirectories_.CreateDirectory(mainFolder);
            CreateDirectories.CreateDirectories_.CreateDirectory(input);
            CreateDirectories.CreateDirectories_.CreateDirectory(output);
            CreateDirectories.CreateDirectories_.CreateDirectory(errors);
            CreateDirectories.CreateDirectories_.CreateDirectory(original);
        
            //Use WatchFolder
            //FileSystemWatcher_Created1(object sender, FileSystemEventArgs e, input, output, errors, original);
            MonitorDirectory(input);
            Console.ReadKey();

        }
        
    }

}