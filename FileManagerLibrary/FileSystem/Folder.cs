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
    
    /// <summary>
    /// создать директорию
    /// </summary>
    public static void Create(string path)
    {
        Directory.CreateDirectory(path);
    }

    /// <summary>
    /// удалить директорию
    /// </summary>
    public static void Delete(string path)
    {
        Directory.Delete(path);
    }

    /// <summary>
    /// переименовать директорию
    /// </summary>
    public static void Rename(string oldName, string newName)
    {
        DirectoryInfo dir = Directory.GetParent(oldName);
        
        Directory.Move(oldName, dir.FullName + newName);
    }
    
    /// <summary>
    /// Копирование папки
    /// </summary>
    /// <param name="pathFrom"></param>
    /// <param name="pathWhere"></param>
    public static void Copy(string pathFrom, string pathWhere)
    {
        Directory.CreateDirectory(pathWhere);

        foreach (var file in Directory.GetFiles(pathFrom))
        {
            File.Copy(file, pathWhere);
        }
        
        foreach (var dir in Directory.GetDirectories(pathFrom))
        {
            Copy(dir, pathWhere);
        }
    }
}