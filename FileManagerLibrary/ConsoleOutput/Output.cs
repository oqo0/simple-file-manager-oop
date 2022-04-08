using FileManagerLibrary.FileSystem;

namespace FileManagerLibrary.ConsoleOutput;

public static class Output
{
    private static PathEntry _path;
    private static List<Folder> _folders = new List<Folder>();
    private static List<FileEntry> _files = new List<FileEntry>();

    public static FilePage Page = new FilePage();
    
    /// <summary>
    /// Показать директории
    /// </summary>
    /// <param name="path"></param>
    public static void ShowDirs(PathEntry path)
    {
        _path = path;
        GetContainedDirs();
        
        foreach (var folder in _folders)
        {
            Console.WriteLine($"{folder.Name, 40} {folder.CreationDateTime, 25}");
        }
    }
    
    /// <summary>
    /// Показать директории в виде файлового дерева
    /// </summary>
    /// <param name="path"></param>
    public static void ShowDirsTree(PathEntry path, int recursionDepth)
    {
        // /home/oqo0/Desktop/   ,  1

        string newPath = String.Empty;
        
        for (int i = 0; i <= recursionDepth; i++)
            newPath += path.PathStr.Split('/')[i];

        _path = new PathEntry(newPath);
        GetContainedDirs();

        foreach (var folder in _folders)
        {
            for (int i = 0; i <= folder.Path.Nesting; i++)
                Console.Write("├── ");
            
            Console.Write(folder.Name + "    " + folder.CreationDateTime + "\n");

            if (folder.Name == _path.PathStr.Split('/')[recursionDepth])
            {
                ShowDirsTree(path, ++recursionDepth);
            }
        }
        
    }
    
    /// <summary>
    /// Показать файлы в директории
    /// </summary>
    /// <param name="path"></param>
    public static void ShowFiles(PathEntry path)
    {
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
            Console.WriteLine($"{file.Name, 40} {file.CreationDateTime, 25} | Size: {file.Size} bytes");
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
}