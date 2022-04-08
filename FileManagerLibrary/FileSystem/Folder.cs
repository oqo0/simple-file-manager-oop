namespace FileManagerLibrary.FileSystem;

public class Folder
{
    public Folder(PathEntry path)
    {
        Path = path;

        GetName();
        GetCreationDateTime();
    }
    
    public PathEntry Path { get; }
    public string Name { get; private set; }
    public DateTime CreationDateTime { get; private set; }

    /// <summary>
    /// Получим имя папки
    /// </summary>
    private void GetName()
    {
        string filePath = Path.PathStr;
        Name = filePath.Split('/')[^1];
    }
    
    /// <summary>
    /// Получим дату и время создания директории
    /// </summary>
    private void GetCreationDateTime()
    {
        CreationDateTime = Directory.GetCreationTime(Path.PathStr);
    }
}