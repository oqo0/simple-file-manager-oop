using FileManagerLibrary.FileSystem;

namespace FileManagerLibrary.ConsoleOutput;

public static class Output
{
    private static PathEntry _path;
    private static List<Folder> _folders = new List<Folder>();
    private static List<FileEntry> _files = new List<FileEntry>();

    public static FilePage Page = new FilePage();

    public static void ShowPath(PathEntry path)
    {
        Console.WriteLine($"Current path: {path.PathStr}");
    }
    
    /// <summary>
    /// Показать директории
    /// </summary>
    /// <param name="path"></param>
    public static void ShowDirs(PathEntry path)
    {
        ShowSeparator();
        
        _path = path;
        GetContainedDirs();
        
        foreach (var folder in _folders)
        {
            Console.WriteLine($"{folder.Name, 32} {folder.CreationDateTime, 25}");
        }
    }
    
    /// <summary>
    /// Показать файлы в директории
    /// </summary>
    /// <param name="path"></param>
    public static void ShowFiles(PathEntry path)
    {
        ShowSeparator();

        _path = path;
        GetContainedFiles();

        int pageSize = 5;
        int startFileIndex = (Page.Index - 1) * pageSize;
        int endFileIndex = (Page.Index - 1) * pageSize + pageSize;

        if (endFileIndex > _files.Count)
            endFileIndex = _files.Count;
        
        for (int i = startFileIndex; i < endFileIndex; i++)
        {
            
            FileEntry file = _files[i];
            Console.WriteLine($"{file.Name, 32} {file.CreationDateTime, 25} | Size: {file.Size} bytes");
        }
    }
    
    /// <summary>
    /// Получим содержащиеся директории
    /// </summary>
    private static void GetContainedDirs()
    {
        _folders.Clear();
        
        foreach (var folder in Directory.GetDirectories(_path.PathStr))
        {
            PathEntry path = new PathEntry(folder);
            _folders.Add(new Folder(path));
        }
    }

    /// <summary>
    /// Получим содержащиеся файлы
    /// </summary>
    private static void GetContainedFiles()
    {
        _files.Clear();
        
        foreach (var folder in Directory.GetFiles(_path.PathStr))
        {
            PathEntry path = new PathEntry(folder);
            _files.Add(new FileEntry(path));
        }
    }

    /// <summary>
    /// Console width line
    /// </summary>
    private static void ShowSeparator()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write("═");
        
        Console.WriteLine();
    }
}