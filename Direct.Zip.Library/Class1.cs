using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Direct.Shared;
using log4net;

namespace Direct.Zip.Library
{
    [DirectSealed]
    [DirectDom("Zip")]
    [ParameterType(false)]
    public class Zip
    {
        private static readonly ILog logArchitect = LogManager.GetLogger(Loggers.LibraryObjects);

        [DirectDom("Zip a folder")]
        [DirectDomMethod("Zip {Folder} to {File Path} and include the Base Directory {true/false}")]
        [MethodDescription("Zip a folder and all its contents into a file.")]
        public static bool ZipFolder(string sourceFolder, string zipFile, bool baseDir)
        {
            try
            {
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.Zip.Library - Zip Folder: " + sourceFolder + " to Zipfile: " + zipFile + "and BaseDir: " + baseDir);
                }
                /**if (!System.IO.Directory.Exists(sourceFolder))
                throw new ArgumentException("sourceDirectory");

                byte[] zipHeader = new byte[] { 80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                using (System.IO.FileStream fs = System.IO.File.Create(zipFile))
                {
                    fs.Write(zipHeader, 0, zipHeader.Length);
                }

                dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
                dynamic source = shellApplication.NameSpace(sourceFolder);
                dynamic destination = shellApplication.NameSpace(zipFile);

                destination.CopyHere(source.Items(), 20);**/

                System.IO.Compression.ZipFile.CreateFromDirectory(sourceFolder, zipFile, System.IO.Compression.CompressionLevel.Optimal, baseDir);
                return true;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.Zip.Library - Convert File to Base64 Exception", e);
                return false;
            }
        }

        [DirectDom("Unzip a folder")]
        [DirectDomMethod("Unzip {Zipfile} to {Folder Path}")]
        [MethodDescription("Unzip a zipfile and all its contents into a folder. Creates folder if does not exist.")]
        public static bool UnzipFile(string zipFile, string targetFolder)
        {
            try {
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.Zip.Library - Unzip Zipfile: " + zipFile + " to Folder: " + targetFolder);
                }
                /**if (!System.IO.Directory.Exists(targetFolder))
                    System.IO.Directory.CreateDirectory(targetFolder);

                dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
                dynamic compressedFolderContents = shellApplication.NameSpace(zipFile).Items;
                dynamic destinationFolder = shellApplication.NameSpace(targetFolder);

                destinationFolder.CopyHere(compressedFolderContents);**/

                System.IO.Compression.ZipFile.ExtractToDirectory(zipFile, targetFolder);
                return true;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.Zip.Library - Convert File to Base64 Exception", e);
                return false;
            }
}
    }
}

