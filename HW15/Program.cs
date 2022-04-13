using System.IO.Compression;
using HW15Library;
Console.WriteLine("Введите директорию");
string? path = Console.ReadLine();
Console.WriteLine("Введите имя файла");
string? fileName = Console.ReadLine();
DirectoryInfo dirInfo = new DirectoryInfo(path);

static void  DirScan(DirectoryInfo directory, string file)
{
    if (directory.Exists)
    {    
        foreach (FileInfo tempFile in directory.GetFiles() )
        {
            if (tempFile.Name.Equals(file))
            {
                string compressedFile = $"{tempFile.FullName}.gz";
                {
                    FileStream sourceStream = new FileStream(file, FileMode.OpenOrCreate);
                    FileStream targetStream = File.Create(compressedFile);
                    GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
                    sourceStream.CopyTo(compressionStream);
                    sourceStream.Close();
                    targetStream.Close();
                    compressionStream.Close();
                    Console.WriteLine($"Файл успешно заархивирован. Путь к файлу: {directory.FullName}");
                }
            }
        }
        foreach (DirectoryInfo d in directory.GetDirectories())
        {
            DirScan(d, file);
        }
    }
    
}
if (File.Exists(fileName))
{
    DirScan(dirInfo, fileName);
}
else
{
    throw new UserException("Файл не существует");
}




