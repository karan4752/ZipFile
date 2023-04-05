using System.IO;
using System.IO.Compression;

internal class Program
{
    private static void Main(string[] args)
    {
        const string FOLDER_PATH = @"E:\PhoneData\";
        // string startPath = @"c:\example\start";
        // string zipPath = @"c:\example\result.zip";
        //string extractPath = @"c:\example\extract";
        var dir = Directory.GetDirectories(FOLDER_PATH);
        foreach (var folder in dir)
        {
            MessageDisplay(folder);
            ZippingFolder(folder);
            MessageDisplay("Deleting existing folder");
            DeleteFolderAndFiles(folder);
        }
        //ZipFile.CreateFromDirectory(startPath, zipPath);

        // ZipFile.ExtractToDirectory(zipPath, extractPath);
        MessageDisplay("Process is completed. \n press any key to exit....");
        Console.ReadKey();
    }

    private static void ZippingFolder(string folder)
    {
        MessageDisplay("***********Going to Create ZIP folder *********");
        ZipFile.CreateFromDirectory(folder, folder + ".zip", CompressionLevel.SmallestSize, false);
        MessageDisplay($"***********Create ZIP folder {folder} ended*********");
    }

    private static void MessageDisplay(string v)
    {
        Console.WriteLine(v);
    }

    static void DeleteFolderAndFiles(string path)
    {
        FileDeletion(path);
        var di = Directory.GetDirectories(path);
        foreach (var subDir in di)
        {
            FileDeletion(subDir);
            MessageDisplay($"{subDir} is deleted");
            DeleteFolderAndFiles(subDir);
            Directory.Delete(subDir);
        }
    }

    private static void FileDeletion(string subDir)
    {
        var files = Directory.GetFiles(subDir);
        if (files.Count() > 0)
        {
            foreach (var file in files)
            {
                MessageDisplay($"{file} is deleted");
                File.Delete(file);
            }
        }
        else MessageDisplay($"No files are available in {subDir} ");

    }
}