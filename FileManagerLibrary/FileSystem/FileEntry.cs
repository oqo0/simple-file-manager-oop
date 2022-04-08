using FileManagerLibrary.FileSystem;

namespace FileManagerLibrary;

public class FileEntry
{
    public FileEntry(PathEntry path)
    {
        Path = path;
        
        GetName();
        GetSize();
        GetCreationDateTime();
    }
    
    public PathEntry Path { get; }
    public string Name { get; private set; }
    public long Size { get; private set; }
    public DateTime CreationDateTime { get; private set; }

    /// <summary>
    /// Получим имя файла
    /// </summary>
    private void GetName()
    {
        string filePath = Path.PathStr;
        Name = filePath.Split('/').Last();
    }

    /// <summary>
    /// Получим размер файла
    /// </summary>
    private void GetSize()
    {
        string filePath = Path.PathStr;
        Size = new FileInfo(filePath).Length;
    }

    /// <summary>
    /// Получим дату и время создания файла
    /// </summary>
    private void GetCreationDateTime()
    {
        CreationDateTime = File.GetCreationTime(Path.PathStr);
    }
}