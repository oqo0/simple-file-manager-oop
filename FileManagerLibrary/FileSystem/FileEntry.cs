using FileManagerLibrary.FileSystem;

namespace FileManagerLibrary;

public class FileEntry
{
    public FileEntry(PathEntry path)
    {
        Path = path;

        GetStaticData();
    }
    
    public PathEntry Path { get; }
    public string Name { get; private set; }
    public long Size { get; private set; }
    public DateTime CreationDateTime { get; private set; }
    public long Words { get; private set; }
    public long Lines { get; private set; }
    public long Paragraphs { get; private set; }
    public long Symbols { get; private set; }

    /// <summary>
    /// Получаем статические данные файла
    /// </summary>
    private void GetStaticData()
    {
        string filePath = Path.PathStr;

        Name = filePath.Split('/').Last();
        Size = new FileInfo(filePath).Length;
        CreationDateTime = File.GetCreationTime(filePath);
        
        try
        {
            string fileText = File.ReadAllText(Path.PathStr);
            string[] fileLines = File.ReadAllLines(Path.PathStr);
            
            Words = fileText.Split(' ').Length;
            Lines = fileLines.Length;
            Paragraphs = fileText.Split("   ").Length;
            Symbols = fileText.Length;
        }
        catch
        {
            Words = 0;
            Lines = 0;
            Paragraphs = 0;
            Symbols = 0;
        }
    }

    /// <summary>
    /// создать файл
    /// </summary>
    public static void Create(string path)
    {
        File.Create(path);
    }
    
    /// <summary>
    /// удалить файл
    /// </summary>
    public static void Delete(string path)
    {
        File.Delete(path);
    }
    
    /// <summary>
    /// переименовать файл
    /// </summary>
    /// <param name="oldName">полный путь к файлу с именем</param>
    /// <param name="newName">новое имя файла</param>
    public static void Rename(string oldName, string newName)
    {
        DirectoryInfo dir = Directory.GetParent(oldName);
        
        File.Move(oldName, dir.FullName + newName);
    }

    /// <summary>
    /// Копирование файла
    /// </summary>
    /// <param name="pathFrom"></param>
    /// <param name="pathWhere"></param>
    public static void Copy(string pathFrom, string pathWhere)
    {
        File.Copy(pathFrom, pathWhere);
    }

    public static void ChangeAttributes(string path, System.IO.FileAttributes fileAttributes)
    {
        File.SetAttributes(path, fileAttributes);
    }
}